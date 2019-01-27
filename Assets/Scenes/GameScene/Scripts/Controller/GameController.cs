using Scenes.GameScene.Scripts.Model;
using Scenes.GameScene.Scripts.View;

namespace Scenes.GameScene.Scripts.Controller
{
    public class GameController
    {
        private readonly IGameView view;
        private readonly ISaveScore scoreSaver;
        private readonly IProgressionManager progressionManager;
        private PlanetState state;

        public GameController(
            IGameView view,
            IProgressionManager progressionManager,
            ISaveScore scoreSaver,
            PlanetState state)
        {
            this.view = view;
            this.state = state;
            this.progressionManager = progressionManager;
            this.scoreSaver = scoreSaver;
        }

        public void StartTheGame()
        {
            InitView();
        }

        public void FinishTheGame()
        {
            view.StopSpawning();
            CheckAndSaveHighScore();
            UpdateView();
            view.FinishTheGame(() =>
            {
                
            });
        }

        private void InitView()
        {
            view.TakeDamage = TakeDamage;
            view.DestroyedGas = ProtectedFromGas;
            view.DestroyedRay = ProtectedFromRay;
            view.InitShield(state.ShieldRegenerationTime);
            view.StartTheGame(() =>
            {
                view.StartSpawning();
                UpdateView();
            });
        }

        private void UpdateView()
        {
            var highScore = scoreSaver.ReadHighScore();
            view.SetHighScore(highScore);
            view.SetPlantState(state);
        }


        private void CheckAndSaveHighScore()
        {
            var highScore = scoreSaver.ReadHighScore();
            if (highScore < state.Score)
                scoreSaver.SaveHighScore(state.Score);
        }

        private PlanetState UpdateProgression(PlanetState currentState)
        {
            var progression = progressionManager.GetProgression(currentState.Score);

            currentState = currentState.SetGasSpawnCooldown(progression.GasSpawnCooldown);
            currentState = currentState.SetGasSpeed(progression.GasSpeed);
            currentState = currentState.SetRaySpawnCooldown(progression.RaySpawnCooldown);
            currentState = currentState.SetRaySpeed(progression.RaySpeed);
            currentState = currentState.SetShieldRegenerationTime(progressionManager.ShieldRegenrationTime);

            return currentState;
        }

        private void TakeDamage()
        {
            state = state.SetHealth(state.Health - 1);
            if (state.Health == 0)
            {
                FinishTheGame();
            } else if (state.Health < 0)
            {
                return;
            }
            UpdateView();
        }

        private void ProtectedFromRay()
        {
            if (!state.IsDead)
                UpdateScore(progressionManager.ScorePerRay);
        }

        private void ProtectedFromGas()
        {
            if (!state.IsDead)
                UpdateScore(progressionManager.ScorePerGas);
        }

        private void UpdateScore(int price)
        {
            var score = state.Score + price;
            state = state.SetScore(score);
            state = UpdateProgression(state);
            CheckAndSaveHighScore();
            UpdateView();
        } 
    }
}
