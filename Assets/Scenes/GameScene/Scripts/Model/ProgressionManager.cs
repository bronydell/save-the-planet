using UnityEngine;

namespace Scenes.GameScene.Scripts.Model
{
    [CreateAssetMenu(fileName = "balance", menuName = "Balance Settings", order = 1)]
    public class ProgressionManager : ScriptableObject, IProgressionManager
    {
        [SerializeField]
        private ProgressionDictionary progressionDictionary;

        [SerializeField]
        private int scorePerGas = 100;
        [SerializeField]
        private int scorePerRay = 100;

        public int ScorePerGas => scorePerGas;
        public int ScorePerRay => scorePerRay;

        public Progression GetProgression(int currentScore)
        {
            var currentProgressKey = 0;
            foreach (var progression in progressionDictionary.Keys)
            {
                if (progression <= currentScore && currentProgressKey < progression)
                {
                    currentProgressKey = progression;
                }
            }

            return progressionDictionary[currentProgressKey];
        }
    }
}