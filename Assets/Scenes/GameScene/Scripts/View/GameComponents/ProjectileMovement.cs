using System;
using Jam.CustomAttrs;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class ProjectileMovement : MonoBehaviour
    {
        public Action onDestoroy { set; private get; }

        public Action OnSuccessDestroy { set; private get; }

        [FormerlySerializedAs("Rb")] [SerializeField]
        protected Rigidbody2D Rigidbody;

        [ReadOnly]
        public float Speed;

        public void FaceTowards(Vector3 target)
        {
            transform.up = target - transform.position;
        }

        private void FixedUpdate()
        {
            Rigidbody.velocity = transform.up * Speed * Time.fixedDeltaTime;
        }

        public void IncreaseScore()
        {
            OnSuccessDestroy?.Invoke();
        }

        public virtual void DestroyMe(bool forced)
        {
            onDestoroy?.Invoke();
            Destroy(gameObject);
        }

        public virtual void StartSelfDestroying(float distance)
        {
            // Nothing to do here...
        }
    }
}
