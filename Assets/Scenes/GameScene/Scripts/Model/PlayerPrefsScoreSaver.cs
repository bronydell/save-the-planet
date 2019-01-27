using UnityEngine;

namespace Scenes.GameScene.Scripts.Model
{
    public class PlayerPrefsScoreSaver : ISaveScore
    {
        private const string ScoreKey = "score";
        public void SaveHighScore(int score)
        {
            PlayerPrefs.SetInt(ScoreKey, score);
        }

        public int ReadHighScore()
        {
            return PlayerPrefs.GetInt(ScoreKey, 0);
        }
    }
}