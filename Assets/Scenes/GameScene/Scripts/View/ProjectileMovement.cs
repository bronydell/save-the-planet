using UnityEngine;

namespace Scenes.GameScene.Scripts.View
{
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField]
        protected Rigidbody2D Rb;

        [SerializeField]
        protected float speed;

        public Vector3 target = Vector3.zero;

        public void FaceTowards(Vector3 target)
        {
            transform.up = target - transform.position;
        }

        private void Start()
        {
            FaceTowards(target);
        }

        private void FixedUpdate()
        {
            Rb.velocity = transform.up * speed * Time.fixedDeltaTime;
        }
    }
}
