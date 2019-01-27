using System;
using Scenes.GameScene.Scripts.Animator;
using Scenes.GameScene.Scripts.Model;
using Scenes.GameScene.Scripts.View.Spawner;
using Scenes.GameScene.Scripts.View.UI;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class Earth : MonoBehaviour, IGameView
    {
        private Action takeDamage;

        [Header("Camera controller")]
        [SerializeField]
        private CameraController cameraController;

        [Header("UI Screens")]
        [SerializeField] 
        private StartMenu startScreen;
        [SerializeField] 
        private FinishScreen finishScreen;

        [Header("Shield")]
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
        public Action DestroyedRay { set => raySpawner.OnGainPoints = value; }
        public Action DestroyedGas { set => gasSpawner.OnGainPoints = value; }

        public void SetPlantState(PlanetState state)
        {
            earthStatus.SetHealth(state.Health);
            smileStatus.SetHealth(state.Health);
            finishScreen.SetScore(state.Score);

            raySpawner.Cooldown = state.RaySpawnCooldown;
            raySpawner.ProjectileSpeed = state.RaySpeed;
            gasSpawner.Cooldown = state.GasSpawnCooldown;
            gasSpawner.ProjectileSpeed = state.GasSpeed;
        }

        public void InitShield(float shieldRegerationTime)
        {
            shield.GenerateShield(shieldRegerationTime);
        }

        public void StartSpawning()
        {
            gasSpawner.StartSpawning();
            raySpawner.StartSpawning();
        }

        public void StopSpawning()
        {
            gasSpawner.StopSpawning();
            raySpawner.StopSpawning();
        }

        public void SetHighScore(int score)
        {
            startScreen.SetHighScore(score);
            finishScreen.SetHighScore(score);
        }

        public void StartTheGame(Action onFinishAnimation)
        {
            cameraController.StartTheGameAnimation(onFinishAnimation);
        }

        public void FinishTheGame(Action onFinishAnimation)
        {
            cameraController.FinishTheGameAnimation(() =>
            {
                onFinishAnimation.Invoke();
                finishScreen.ShowDeathAnimation();
            });
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
