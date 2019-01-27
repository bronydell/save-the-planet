using System;
using Scenes.GameScene.Scripts.Model;

namespace Scenes.GameScene.Scripts.View
{
    public interface IGameView
    {
        Action TakeDamage { set; }
        Action DestroyedRay { set; }
        Action DestroyedGas { set; }

        void SetPlantState(PlanetState state);
        void InitShield(float shieldRegenerationTime);
        void StartSpawning();
        void StartTheGame(Action onFinishAnimation);
        void FinishTheGame(Action onFinishAnimation);
    }
}