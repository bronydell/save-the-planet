using System;
using Scenes.GameScene.Scripts.Animator;
using Scenes.GameScene.Scripts.Model;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class Earth : MonoBehaviour, IGameView
    {
        private Action takeDamage;
        [SerializeField]
        private HealthAnimator smileStatus;

        public Action TakeDamage { set => takeDamage = value; }

        public void SetPlantState(PlanetState state)
        {
            smileStatus.SetHealth(state.Health);
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
