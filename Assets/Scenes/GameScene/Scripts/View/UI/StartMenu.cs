using TMPro;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.UI
{
    public class StartMenu : MonoBehaviour
    {
        private EntryPoint gameController;

        [SerializeField]
        private TextMeshProUGUI highScoreText;

        private void Start()
        {
            gameController = FindObjectOfType<EntryPoint>();
        }

        public void StartGame()
        {
            gameController.StartGame();
        }

        public void SetHighScore(int score)
        {
            highScoreText.SetText($"High Score: {score}");
        }
    }
}