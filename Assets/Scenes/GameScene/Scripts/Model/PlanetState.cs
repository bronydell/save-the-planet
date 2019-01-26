namespace Assets.Scenes.GameScene.Scripts.Model
{
    public class PlanetState
    {
        public int Health { get; }

        public PlanetState(int health)
        {
            Health = health;
        }

        public PlanetState SetHealth(int health)
        {
            return new PlanetState(health);
        }
    }
}
