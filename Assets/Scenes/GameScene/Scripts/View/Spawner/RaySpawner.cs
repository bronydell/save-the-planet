using System.Collections;
using Scenes.GameScene.Scripts.View.GameComponents;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.Spawner
{
    public class RaySpawner : RadiusSpawner
    {
        [SerializeField]
        private float cooldown = 1;
        [SerializeField]
        private Transform faceTowardsTarget;
        [SerializeField]
        private GameObject ray;
    
        private void Start()
        {
            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            StartCoroutine(SpawnProjectile(ray));
        }

        private IEnumerator SpawnProjectile(GameObject ray)
        {
            yield return new WaitForSeconds(cooldown);
            var movement = Spawn(ray).GetComponent<ProjectileMovement>();
            movement.FaceTowards(faceTowardsTarget.position);
            SpawnProjectile();
        }
    }
}
