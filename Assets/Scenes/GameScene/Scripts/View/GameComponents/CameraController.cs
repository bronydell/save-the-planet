using System;
using DG.Tweening;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 gamePoint;
        [SerializeField]
        private float gamePointDuaration;
        [SerializeField]
        private Vector3 finishPoint;
        [SerializeField]
        private float finishPointDuaration;

        public void StartTheGameAnimation(Action onFinishAnimation)
        {
            var seq = DOTween.Sequence();
            seq.Append(transform.DOMove(gamePoint, gamePointDuaration));
            seq.AppendCallback(onFinishAnimation.Invoke);
        }

        public void FinishTheGameAnimation(Action onFinishAnimation)
        {
            var seq = DOTween.Sequence();
            seq.Append(transform.DOMove(finishPoint, finishPointDuaration));
            seq.AppendCallback(onFinishAnimation.Invoke);
        }
    }
}