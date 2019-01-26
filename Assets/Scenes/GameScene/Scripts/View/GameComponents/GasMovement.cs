using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class GasMovement : ProjectileMovement
    {
        private SpriteRenderer spriteRenderer;

        [SerializeField] private float transparancyAnimationTime = 1f;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public override void StartSelfDestroying(float distance)
        {
            StartCoroutine(DestroyMeAfterTime(distance / 100 * speed));
        }

        public override void DestroyMe(bool forced)
        {
            if (forced)
            {
                base.DestroyMe(true);
                return;
            }

            var sequence = DOTween.Sequence();
            sequence.Append(spriteRenderer.DOFade(0, transparancyAnimationTime));
            sequence.AppendCallback(() => base.DestroyMe(false));
        }

        private IEnumerator DestroyMeAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            DestroyMe(false);
        }
    }
}
