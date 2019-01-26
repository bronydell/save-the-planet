using System;
using Scenes.GameScene.Scripts.Animator;
using Scenes.GameScene.Scripts.Model;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class Earth : MonoBehaviour, IGameView
    {
        private Action takeDamage;
        [SerializeField]
        private HealthAnimator smileStatus;
        [SerializeField]
        private HealthAnimator earthStatus;

        public Action TakeDamage { set => takeDamage = value; }

        public void SetPlantState(PlanetState state)
        {
            earthStatus.SetHealth(state.Health);
            smileStatus.SetHealth(state.Health);
        }

        [ContextMenu("Damage Self")]
        public void DamageSelf()
        {
            takeDamage.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("SunRay"))
            {
                collision.gameObject.GetComponent<ProjectileMovement>().DestroyMe(true);
                takeDamage.Invoke();
            }
        }
    }
}
