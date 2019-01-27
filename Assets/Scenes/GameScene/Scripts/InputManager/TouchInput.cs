using UnityEngine;

namespace Scenes.GameScene.Scripts.InputManager
{
    public class TouchInput : MonoBehaviour
    {
        [SerializeField]
        private InputManager inputManager;

        private int screenWidth = 0;
        private int screenHeight = 0;

        private void Start()
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;
        }

        private void FixedUpdate()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.position.x > screenWidth / 2)
                    inputManager.MoveLeft();
                else
                    inputManager.MoveRight();
            }
        }
    }
}