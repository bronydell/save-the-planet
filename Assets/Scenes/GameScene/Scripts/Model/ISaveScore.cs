namespace Scenes.GameScene.Scripts.Model
{
    public interface ISaveScore
    {
        void SaveHighScore(int score);
        int ReadHighScore();
    }
}