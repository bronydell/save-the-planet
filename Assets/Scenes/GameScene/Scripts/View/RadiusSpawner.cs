using UnityEngine;

public class RadiusSpawner : MonoBehaviour
{
    public float Radius = 5;

    public void Spawn(GameObject prefab)
    {
        var pos = RandomPointAtRadius() * Radius;
        Instantiate(prefab, pos, Quaternion.identity);
    }

    private Vector2 RandomPointAtRadius()
    {
        return Random.insideUnitCircle.normalized;
    }
}
