using Scenes.GameScene.Scripts.Controller;
using Scenes.GameScene.Scripts.Model;
using UnityEngine;

namespace Scenes.GameScene.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        public void Start()
        {
            var view = FindObjectOfType<View.View>();
            var controller = new GameController(view, new PlanetState(5));
            controller.StartTheGame();
        }
    }
}