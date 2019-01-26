using System;
using Scenes.GameScene.Scripts.Model;

namespace Scenes.GameScene.Scripts.View
{
    public interface IGameView
    {
        Action TakeDamage { set; }

        void SetPlantState(PlanetState state);
    }
}