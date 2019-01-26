using Scenes.GameScene.Scripts.Model;
using Scenes.GameScene.Scripts.View;

namespace Scenes.GameScene.Scripts.Controller
{
    public class GameController
    {
        private IGameView view;
        private PlanetState state;

        public GameController(IGameView view, PlanetState state)
        {
            this.view = view;
            this.state = state;
        }

        public void StartTheGame()
        {
            InitView();
        }

        private void InitView()
        {
            view.TakeDamage = TakeDamage;
            UpdateView();
        }

        private void UpdateView()
        {
            view.SetPlantState(state);
        }        

        private void TakeDamage()
        {
            state = state.SetHealth(state.Health - 1);
            UpdateView();
        }
    }
}
