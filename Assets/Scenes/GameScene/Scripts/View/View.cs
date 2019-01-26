using System;
using UnityEngine;

namespace Assets.Scenes.GameScene.Scripts.View
{
    public class View : MonoBehaviour, IGameView
    {
        public Action TakeDamage { get; set; }

        public void DamagePlanet()
        {
            TakeDamage();
        }
    }
}
