﻿using Scenes.GameScene.Scripts.Controller;
using Scenes.GameScene.Scripts.Model;
using UnityEngine;
using Scenes.GameScene.Scripts.View.GameComponents;

namespace Scenes.GameScene.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private Earth earth;

        public void Start()
        {
            var controller = new GameController(earth, new PlanetState(4));
            controller.StartTheGame();
        }
    }
}