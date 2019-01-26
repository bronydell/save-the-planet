using System.Collections;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View
{
    public class RaySpawner : RadiusSpawner
    {
        [SerializeField]
        private float cooldown = 1;
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
            Spawn(ray);
            yield return new WaitForSeconds(cooldown);
            SpawnProjectile();
        }
    }
}
