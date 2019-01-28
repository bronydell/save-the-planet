using Scenes.GameScene.Scripts.View.GameComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.Spawner
{
    public class Spawner : RadiusSpawner
    {
        [HideInInspector]
        public Action OnGainPoints;
        public float ProjectileSpeed;
        public float Cooldown = 1;
        [SerializeField]
        protected GameObject SpawnObjectPrefab;

        public void StartSpawning()
        {
            SpawnProjectile();
        }

        public void StopSpawning()
        {
            StopAllCoroutines();
        }

        private void SpawnProjectile()
        {
            StartCoroutine(SpawnProjectile(SpawnObjectPrefab));
        }

        private IEnumerator SpawnProjectile(GameObject ray)
        {
            yield return new WaitForSeconds(Cooldown);
            SpawnLogic();
            SpawnProjectile();
        }

        protected virtual void SpawnLogic()
        {
            // Nothing lol
        }
    }
}