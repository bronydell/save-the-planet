using System;
using System.Collections;
using System.Collections.Generic;
using Scenes.GameScene.Scripts.View.GameComponents;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.Spawner
{
    public class GasSpawner : Spawner
    {
        [SerializeField]
        private Shield shield;
        [SerializeField]
        private SpriteRenderer earth;
        [SerializeField]
        private RaySpawner raySpawner;
        

        protected override void Start()
        {
            Radius = earth.bounds.size.x / 2;
            base.Start();
        }

        protected override void SpawnLogic()
        {
            var movement = Spawn(SpawnObjectPrefab, GetObsticles());
            movement.OnSuccessDestroy = OnGainPoints;
            movement.FaceTowards(movement.transform.position * 2);
            movement.StartSelfDestroying(shield.Radius);
            movement.Speed = ProjectileSpeed;
        }

        protected override List<Transform> GetObsticles()
        {
            return raySpawner.SpawnedObjects;
        }
    }
}