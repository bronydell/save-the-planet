using UnityEngine;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField]
        protected Rigidbody2D Rb;

        [SerializeField]
        protected float speed;

        public void FaceTowards(Vector3 target)
        {
            transform.up = target - transform.position;
        }

        private void FixedUpdate()
        {
            Rb.velocity = transform.up * speed * Time.fixedDeltaTime;
        }

        public virtual void DestroyMe(bool forced)
        {
            Destroy(gameObject);
        }

        public virtual void StartSelfDestroying(float distance)
        {
            // Nothing to do here...
        }
    }
}
