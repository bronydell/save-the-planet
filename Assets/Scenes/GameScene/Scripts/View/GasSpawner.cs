using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.Networking;

namespace Scenes.GameScene.Scripts.View
{
    public class GasSpawner : RadiusSpawner
    {
        [SerializeField]
        private float cooldown = 1;
        [SerializeField]
        private GameObject gas;
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
            GameObject obj = Spawn(gas);
            yield return new WaitForSeconds(cooldown);
            SpawnProjectile();
        }
    }
}