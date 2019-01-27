using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class GasMovement : ProjectileMovement
    {
        private SpriteRenderer spriteRenderer;

        [SerializeField] private float transparencyAnimationTime = 1f;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public override void StartSelfDestroying(float distance)
        {
            StartCoroutine(DestroyMeAfterTime(distance / Speed * 25));
        }

        public override void DestroyMe(bool forced)
        {
            if (forced)
            {
                base.DestroyMe(true);
                return;
            }

            var sequence = DOTween.Sequence();
            sequence.Append(spriteRenderer.DOFade(0, transparencyAnimationTime));
            sequence.AppendCallback(() => base.DestroyMe(false));
        }

        private IEnumerator DestroyMeAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            IncreaseScore();
            DestroyMe(false);
        }
    }
}
