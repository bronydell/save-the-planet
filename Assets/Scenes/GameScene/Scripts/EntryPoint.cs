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

        private PlanetState GetDefaultState()
        {
            var progression = progressionManager.GetProgression(0);
            return new PlanetState(4,
                progression.GasSpeed, progression.RaySpeed,
                progression.GasSpawnCooldown, progression.RaySpawnCooldown,
                0
            );
        }

        public void StartGame()
        {
            var startState = GetDefaultState();
            gameController = new GameController(earth, progressionManager, startState);
            gameController.StartTheGame();
        }

        public void FinishGame()
        {
            var startState = GetDefaultState();
            gameController.FinishTheGame();
        }
    }
}