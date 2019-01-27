using System;
using System.Collections;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class PieceOfShield : MonoBehaviour
    {
        public Action OnDestroyRay { set; private get; }

        public PieceOfShield prev;
        public PieceOfShield next;

        [SerializeField]
        private int destroyRadius = 1;

        public float regenTimer = 5;

        private CapsuleCollider2D collider;
        private SpriteRenderer renderer;

        private void Start()
        {
            collider = GetComponent<CapsuleCollider2D>();
            renderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var movement = collision.gameObject.GetComponent<ProjectileMovement>();

            if (collision.gameObject.CompareTag("SunRay"))
            {
                if (movement != null)
                {
                    OnDestroyRay?.Invoke();
                    movement.IncreaseScore();
                    movement.DestroyMe(true);
                }
            }
            if (collision.gameObject.CompareTag("Gas"))
            {
                DestroyMe(destroyRadius);
                if (movement != null)
                    movement.DestroyMe(true);
                
            }
        }

        private void DestroyMe(int radius)
        {
            StartCoroutine(Regen());

            int index = transform.GetSiblingIndex();
            if (prev != null && radius > 0)
            {
                int prevIndex = (index - 1 + transform.parent.childCount) % transform.parent.childCount;
                transform.parent.GetChild(prevIndex).GetComponent<PieceOfShield>().DestroyMe(radius - 1);
            }
            if (next != null && radius > 0)
            {
                int nextIndex = (index + 1 + transform.parent.childCount) % transform.parent.childCount;
                transform.parent.GetChild(nextIndex).GetComponent<PieceOfShield>().DestroyMe(radius - 1);
            }
        }

        private IEnumerator Regen()
        {
            SetDisabled(true);
            yield return new WaitForSeconds(regenTimer);
            SetDisabled(false);
        }

        private void SetDisabled(bool disabled)
        {
            renderer.enabled = !disabled;
            collider.enabled = !disabled;
        }
    }
}
