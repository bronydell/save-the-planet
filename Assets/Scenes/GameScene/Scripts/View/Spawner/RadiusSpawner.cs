using UnityEngine;
using Scenes.GameScene.Scripts.View.GameComponents;
using static WheelSpawner;

namespace Scenes.GameScene.Scripts.View.Spawner
{
    public class RadiusSpawner : MonoBehaviour
    {
        [SerializeField]
        protected float Radius = 5;
        [SerializeField]
        protected WheelSpawner wheelSpawner;

        public ProjectileMovement Spawn(GameObject prefab)
        {
            var vec = wheelSpawner.getVector();
            if (vec == Vector2.zero)
                return null;
            var movement = Instantiate(prefab, vec * Radius, Quaternion.identity).GetComponent<ProjectileMovement>();
            movement.onDestoroy = () => { wheelSpawner.freeVector(vec); };
            return movement;
        }
    }
}
