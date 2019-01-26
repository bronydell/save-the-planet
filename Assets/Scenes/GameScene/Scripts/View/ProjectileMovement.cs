using UnityEngine;

namespace Scenes.GameScene.Scripts.View
{
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D Rb;

        [SerializeField]
        private float speed;

        public void FaceTowards(Vector3 target)
        {
            transform.up = target - transform.position;
        }

        private void Start()
        {
            FaceTowards(Vector3.zero);
        }

        private void FixedUpdate()
        {
            Rb.velocity = transform.up * speed * Time.fixedDeltaTime;
        }
    }
}
