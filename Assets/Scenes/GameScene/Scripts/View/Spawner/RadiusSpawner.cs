using UnityEngine;
using System.Collections.Generic;
using Scenes.GameScene.Scripts.View.GameComponents;

namespace Scenes.GameScene.Scripts.View.Spawner
{
    public class RadiusSpawner : MonoBehaviour
    {
        [SerializeField]
        protected float Radius = 5;

        private Vector2 treshold = new Vector2(0.2f, 0.2f);

        public ProjectileMovement Spawn(GameObject prefab, List<Transform> obstacles = null, int invertDir = 1)
        {
            Vector2 pos = RandomPointAtRadius() * Radius;
            /*bool isOk = true;

            do
            {
                pos = RandomPointAtRadius() * Radius;
                foreach (var obstacle in obstacles)
                {
                    var obsticleVector = obstacle.transform.up;
                    if (WrongDirection(pos * invertDir, obsticleVector))
                    {
                        isOk = false;
                        break;
                    }
                    else
                    {
                        isOk = true;
                    }
                }
            } while (!isOk);*/
            
            return Instantiate(prefab, pos, Quaternion.identity).GetComponent<ProjectileMovement>();
        }

        protected Vector2 RandomPointAtRadius()
        {
            return Random.insideUnitCircle.normalized;
            //return new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        }

        private Vector2 Abs(Vector2 vector)
        {
            return new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        }

        private bool WrongDirection(Vector2 dir, Vector2 obstacle)
        {
            var composition = Abs(dir.normalized + obstacle);
            
            return composition.x < treshold.x && composition.y < treshold.y;
        }
    }
}
