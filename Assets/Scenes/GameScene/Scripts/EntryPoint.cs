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

        private PlanetState GetDefaultState()
        {
            var progression = progressionManager.GetProgression(0);
            return new PlanetState(4,
                progression.GasSpeed, progression.RaySpeed,
                progression.GasSpawnCooldown, progression.RaySpawnCooldown,
                0
            );
        }

        public void Start()
        {
            var startState = GetDefaultState();
            var controller = new GameController(earth, progressionManager, startState);
            controller.StartTheGame();
        }
    }
}