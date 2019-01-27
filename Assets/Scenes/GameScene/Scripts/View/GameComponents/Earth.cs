using System;
using Scenes.GameScene.Scripts.Animator;
using Scenes.GameScene.Scripts.Model;
using Scenes.GameScene.Scripts.View.Spawner;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class Earth : MonoBehaviour, IGameView
    {
        private Action takeDamage;

        [SerializeField]
        private Shield shield;

        [Header("Spawners")]
        [SerializeField]
        private GasSpawner gasSpawner;
        [SerializeField]
        private RaySpawner raySpawner;

        [Header("Health animators")]
        [SerializeField]
        private HealthAnimator smileStatus;
        [SerializeField]
        private HealthAnimator earthStatus;

        public Action TakeDamage { set => takeDamage = value; }
        public Action DestroyedRay { set => raySpawner.onGainPoints = value; }
        public Action DestroyedGas { set => gasSpawner.onGainPoints = value; }

        public void SetPlantState(PlanetState state)
        {
            earthStatus.SetHealth(state.Health);
            smileStatus.SetHealth(state.Health);
            Debug.Log($"Score is {state.Score}");
        }

        public void InitShield()
        {
            shield.GenerateShield();
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
