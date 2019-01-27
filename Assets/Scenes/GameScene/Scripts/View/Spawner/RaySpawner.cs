using System.Collections.Generic;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.Spawner
{
    public class RaySpawner : Spawner
    {
        [SerializeField]
        private Transform faceTowardsTarget;
        public GasSpawner gasSpawner;

        protected override void SpawnLogic()
        {
            var movement = Spawn(spawnObjectPrefab, GetObsticles(), -1);
            var movementTransform = movement.transform;
            SpawnedObjects.Add(movementTransform);
            movement.OnSuccessDestroy = OnGainPoints;
            movement.onDestoroy = () => { SpawnedObjects.Remove(movementTransform); };
            movement.FaceTowards(faceTowardsTarget.position);
            movement.Speed = ProjectileSpeed;
        }

        protected override List<Transform> GetObsticles()
        {
            return gasSpawner.SpawnedObjects;
        }
    } 
}
