﻿using Scenes.GameScene.Scripts.View.GameComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.Spawner
{
    public class Spawner : RadiusSpawner
    {
        [HideInInspector]
        public Action onGainPoints;
        [SerializeField]
        private float cooldown = 1;
        [SerializeField]
        protected GameObject spawnObjectPrefab;

        /** List of all spawner rays */
        public List<Transform> SpawnedObjects;

        protected virtual void Start()
        {
            SpawnedObjects = new List<Transform>();
            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            StartCoroutine(SpawnProjectile(spawnObjectPrefab));
        }

        private IEnumerator SpawnProjectile(GameObject ray)
        {
            yield return new WaitForSeconds(cooldown);
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