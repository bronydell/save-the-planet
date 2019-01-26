using UnityEngine;

namespace Scenes.GameScene.Scripts.InputManager
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        [SerializeField]
        private float moveSpeed = 1f;

        public void MoveLeft()
        {
            Move(1);
        }

        public void MoveRight()
        {
            Move(-1);
        }

        public void Move(float direction)
        {
            var turnSpeed = moveSpeed * Time.deltaTime;
            var rotation = direction * turnSpeed;
            target.Rotate(Vector3.forward * rotation);
        }
    }
}
