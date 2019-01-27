using Scenes.GameScene.Scripts.Controller;
using Scenes.GameScene.Scripts.Model;
using UnityEngine;
using Scenes.GameScene.Scripts.View.GameComponents;

namespace Scenes.GameScene.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private Earth earth;
        [SerializeField]
        private ProgressionManager progressionManager;

        private GameController gameController;
        private ISaveScore scoreSaver;

        private void Start()
        {
            scoreSaver = new PlayerPrefsScoreSaver();
            earth.SetHighScore(scoreSaver.ReadHighScore());
        }

        private PlanetState GetDefaultState()
        {
            var progression = progressionManager.GetProgression(0);
            return new PlanetState(4,
                progression.GasSpeed, progression.RaySpeed,
                progression.GasSpawnCooldown, progression.RaySpawnCooldown,
                0, progressionManager.ShieldRegenrationTime
            );
        }

        public void StartGame()
        {
            var startState = GetDefaultState();
            gameController = new GameController(earth, progressionManager, scoreSaver, startState);
            gameController.StartTheGame();
        }

        public void FinishGame()
        {
            gameController.FinishTheGame();
        }
    }
}