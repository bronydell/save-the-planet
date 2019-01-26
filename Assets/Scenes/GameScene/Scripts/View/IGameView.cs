using System;

namespace Assets.Scenes.GameScene.Scripts.View
{
    public interface IGameView
    {
        Action TakeDamage { get; set; }
    }
}