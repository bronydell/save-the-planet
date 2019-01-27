namespace Scenes.GameScene.Scripts.Model
{
    public class PlanetState
    {
        public int Score { get; }
        public int Health { get; }
        public float GasSpeed { get; }
        public float RaySpeed { get; }

        public float GasSpawnCooldown { get; }
        public float RaySpawnCooldown { get; }
        public float ShieldRegenerationTime { get; }

        public PlanetState(int health, float gasSpeed,
            float raySpeed, float gasSpawnCooldown,
            float raySpawnCooldown, int score, float shieldRegenerationTime)
        {
            Health = health;
            GasSpeed = gasSpeed;
            RaySpeed = raySpeed;
            GasSpawnCooldown = gasSpawnCooldown;
            RaySpawnCooldown = raySpawnCooldown;
            Score = score;
            ShieldRegenerationTime = shieldRegenerationTime;
        }

        public PlanetState SetHealth(int health)
        {
            return new PlanetState(health, GasSpeed, RaySpeed, GasSpawnCooldown, RaySpawnCooldown, Score, ShieldRegenerationTime);
        }

        public PlanetState SetGasSpeed(float gasSpeed)
        {
            return new PlanetState(Health, gasSpeed, RaySpeed, GasSpawnCooldown, RaySpawnCooldown, Score, ShieldRegenerationTime);
        }

        public PlanetState SetRaySpeed(float raySpeed)
        {
            return new PlanetState(Health, GasSpeed, raySpeed, GasSpawnCooldown, RaySpawnCooldown, Score, ShieldRegenerationTime);
        }

        public PlanetState SetGasSpawnCooldown(float gasSpawnCooldown)
        {
            return new PlanetState(Health, GasSpeed, RaySpeed, gasSpawnCooldown, RaySpawnCooldown, Score, ShieldRegenerationTime);
        }

        public PlanetState SetRaySpawnCooldown(float raySpawnCooldown)
        {
            return new PlanetState(Health, GasSpeed, RaySpeed, GasSpawnCooldown, raySpawnCooldown, Score, ShieldRegenerationTime);
        }

        public PlanetState SetScore(int score)
        {
            return new PlanetState(Health, GasSpeed, RaySpeed, GasSpawnCooldown, RaySpawnCooldown, score, ShieldRegenerationTime);
        }

        public PlanetState SetShieldRegenerationTime(float shieldRegenerationTime)
        {
            return new PlanetState(Health, GasSpeed, RaySpeed, GasSpawnCooldown, RaySpawnCooldown, Score, shieldRegenerationTime);
        }
    }
}
