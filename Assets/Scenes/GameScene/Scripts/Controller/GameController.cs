using Scenes.GameScene.Scripts.Model;
using Scenes.GameScene.Scripts.View;

namespace Scenes.GameScene.Scripts.Controller
{
    public class GameController
    {
        private readonly IGameView view;
        private readonly IProgressionManager progressionManager;
        private PlanetState state;

        public GameController(
            IGameView view,
            IProgressionManager progressionManager,
            PlanetState state)
        {
            this.view = view;
            this.state = state;
            this.progressionManager = progressionManager;
        }

        public void StartTheGame()
        {
            InitView();
        }

        public void FinishTheGame()
        {
        }

        private void InitView()
        {
            view.TakeDamage = TakeDamage;
            view.DestroyedGas = ProtectedFromGas;
            view.DestroyedRay = ProtectedFromRay;
            view.InitShield();
            view.StartTheGame(() =>
            {
                view.StartSpawning();
                UpdateView();
            });
        }

        private void UpdateView()
        {
            view.SetPlantState(state);
        }

        private PlanetState UpdateProgression(PlanetState currentState)
        {
            var progression = progressionManager.GetProgression(currentState.Score);

            currentState = currentState.SetGasSpawnCooldown(progression.GasSpawnCooldown);
            currentState = currentState.SetGasSpeed(progression.GasSpeed);
            currentState = currentState.SetRaySpawnCooldown(progression.RaySpawnCooldown);
            currentState = currentState.SetRaySpeed(progression.RaySpeed);

            return currentState;
        }

        private void TakeDamage()
        {
            state = state.SetHealth(state.Health - 1);
            UpdateView();
        }

        private void ProtectedFromRay()
        {
            UpdateScore(progressionManager.ScorePerRay);
        }

        private void ProtectedFromGas()
        {
            UpdateScore(progressionManager.ScorePerGas);
        }

        private void UpdateScore(int price)
        {
            var score = state.Score + price;
            state = state.SetScore(score);
            state = UpdateProgression(state);
            UpdateView();
        } 
    }
}
