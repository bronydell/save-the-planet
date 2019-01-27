namespace Scenes.GameScene.Scripts.Model
{
    public interface IProgressionManager
    {
        int ScorePerGas { get; }
        int ScorePerRay { get; }
        float ShieldRegenrationTime { get; }
        Progression GetProgression(int currentScore);
    }
}