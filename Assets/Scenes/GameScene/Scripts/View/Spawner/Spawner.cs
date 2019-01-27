using Scenes.GameScene.Scripts.View.GameComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using Jam.CustomAttrs;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.Spawner
{
    public class Spawner : RadiusSpawner
    {
        [HideInInspector]
        public Action OnGainPoints;
        [ReadOnly]
        public float ProjectileSpeed;
        [ReadOnly]
        public float Cooldown = 1;
        [SerializeField]
        protected GameObject SpawnObjectPrefab;

        /** List of all spawner rays */
        public List<Transform> SpawnedObjects;

        protected virtual void Start()
        {
            SpawnedObjects = new List<Transform>();
        }

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

        protected virtual List<Transform> GetObsticles()
        {
            return new List<Transform>();
        }
    }
}