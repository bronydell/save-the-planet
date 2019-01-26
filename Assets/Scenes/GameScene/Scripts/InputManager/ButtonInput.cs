using UnityEngine;

namespace Assets.Scenes.GameScene.Scripts.InputManager
{
    public class ButtonInput : MonoBehaviour
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
            if (Input.GetKey(KeyCode.LeftArrow))
                inputManager.MoveLeft();
            else if (Input.GetKey(KeyCode.RightArrow))
                inputManager.MoveRight();
        }
    }
}