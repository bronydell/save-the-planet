using Assets.Scenes.GameScene.Scripts.View;

namespace Assets.Scenes.GameScene.Scripts.Controller
{
    public class GameController
    {
        private IGameView view;

        public GameController(IGameView view)
        {
            this.view = view;
        }

        private void UpdateView()
        {

        }        

        private void TakeDamage()
        {
            // TODO: Some logic goes here...
        }
    }
}
