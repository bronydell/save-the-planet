using System;
using Assets.Scenes.GameScene.Scripts.Model;

namespace Assets.Scenes.GameScene.Scripts.View
{
    public interface IGameView
    {
        Action TakeDamage { set; }

        void SetPlantState(PlanetState state);
    }
}