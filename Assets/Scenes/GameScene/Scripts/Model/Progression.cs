using System;

namespace Scenes.GameScene.Scripts.Model
{
    [Serializable]
    public class ProgressionDictionary : SerializableDictionary<int, Progression> { }

    [Serializable]
    public class Progression
    {
        public float GasSpeed = 1f;
        public float RaySpeed = 0.5f;

        public float GasSpawnCooldown = 1.5f;
        public float RaySpawnCooldown = 2f;
    }
}