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

        protected void Start()
        {
            Radius = earth.bounds.size.x / 2;
        }

        protected override void SpawnLogic()
        {
            var movement = Spawn(SpawnObjectPrefab);
            if (movement == null)
                return;
            movement.OnSuccessDestroy = OnGainPoints;
            movement.FaceTowards(movement.transform.position * 2);
            movement.Speed = ProjectileSpeed;
            movement.StartSelfDestroying(shield.Radius);
        }
    }
}