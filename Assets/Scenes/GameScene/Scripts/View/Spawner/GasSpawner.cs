using System.Collections;
using Scenes.GameScene.Scripts.View.GameComponents;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.Spawner
{
    public class GasSpawner : RadiusSpawner
    {
        [SerializeField]
        private float cooldown = 1;
        [SerializeField]
        private GameObject gas;
        [SerializeField]
        private Shield shield;
        [SerializeField]
        private SpriteRenderer earth;

        private void Start()
        {
            
            Radius = earth.bounds.size.x / 2;
            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            StartCoroutine(SpawnProjectile(gas));
        }

        private IEnumerator SpawnProjectile(GameObject gas)
        {
            yield return new WaitForSeconds(cooldown);
            var gasObj = Spawn(gas);
            var movement = gasObj.GetComponent<ProjectileMovement>();
            movement.FaceTowards(gasObj.transform.position * 2);
            movement.StartSelfDestroying(shield.Radius);
            SpawnProjectile();
        }
    }
}