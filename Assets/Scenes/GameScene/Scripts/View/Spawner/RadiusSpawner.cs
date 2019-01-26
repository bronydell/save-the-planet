using UnityEngine;

namespace Scenes.GameScene.Scripts.View.Spawner
{
    public class RadiusSpawner : MonoBehaviour
    {
        [SerializeField]
        protected float Radius = 5;

        public GameObject Spawn(GameObject prefab)
        {
            var pos = RandomPointAtRadius() * Radius;
            return Instantiate(prefab, pos, Quaternion.identity);
        }

        protected Vector2 RandomPointAtRadius()
        {
            return Random.insideUnitCircle.normalized;
        }
    }
}
