using System.Collections.Generic;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.Spawner
{
    public class RaySpawner : Spawner
    {
        [SerializeField]
        private Transform faceTowardsTarget;

        protected override void SpawnLogic()
        {
            var movement = Spawn(SpawnObjectPrefab);
            if (movement == null)
                return;
            var movementTransform = movement.transform;
            movement.OnSuccessDestroy = OnGainPoints;
            movement.FaceTowards(faceTowardsTarget.position);
            movement.Speed = ProjectileSpeed;
        }
    } 
}
