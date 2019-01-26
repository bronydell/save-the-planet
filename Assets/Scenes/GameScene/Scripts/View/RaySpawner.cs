using UnityEngine;
using System.Collections;

public class RaySpawner : MonoBehaviour
{
    [SerializeField]
    private float Cooldown = 1;
    [SerializeField]
    private float SpawnRadius;
    [SerializeField]
    private RadiusSpawner Spawner;
    [SerializeField]
    private GameObject Ray;

    private float timer;
    
    void Start()
    {
        timer = 0;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= Cooldown)
        {
            timer = 0;
            Spawner.Radius = SpawnRadius;
            Spawner.Spawn(Ray);
        }
    }
}
