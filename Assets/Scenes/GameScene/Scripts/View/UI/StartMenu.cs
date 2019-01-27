using UnityEngine;

namespace Scenes.GameScene.Scripts.View.UI
{
    public class StartMenu : MonoBehaviour
    {
        private EntryPoint gameController;

        private void Start()
        {
            gameController = FindObjectOfType<EntryPoint>();
        }

        public void StartGame()
        {
            gameController.StartGame();
        }
    }
}