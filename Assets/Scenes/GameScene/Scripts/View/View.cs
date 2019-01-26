using System;
using Scenes.GameScene.Scripts.Model;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View
{
    public class View : MonoBehaviour, IGameView
    {
        // TODO: Remove it and implement actual thing
        [SerializeField]
        private DemoUi demoUi;
        [SerializeField]
        private GameObject shield;

        public Action TakeDamage
        {
            set => demoUi.SetOnDamage(value);
        }

        public void SetPlantState(PlanetState state)
        {
            demoUi.SetHealth(state.Health);
        }
    }
}
