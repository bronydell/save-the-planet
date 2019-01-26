using System;
using Scenes.GameScene.Scripts.Animator;
using Scenes.GameScene.Scripts.Model;
using Scenes.GameScene.Scripts.View.UI;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View
{
    public class View : MonoBehaviour, IGameView
    {
        // TODO: Remove it and implement actual thing
        [SerializeField]
        private DemoUi demoUi;
        [SerializeField]
        private HealthAnimator smileStatus;
        [SerializeField]
        private GameObject shield;

        public Action TakeDamage
        {
            set => demoUi.SetOnDamage(value);
        }

        public void SetPlantState(PlanetState state)
        {
            smileStatus.SetHealth(state.Health);
        }
    }
}
