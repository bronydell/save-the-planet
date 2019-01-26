using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.Networking;

public class RaySpawner : RadiusSpawner
{
    [SerializeField]
    private float cooldown = 1;
    [SerializeField]
    private GameObject ray;
    
    private void Start()
    {
        SpawnProjectile();
    }

    private void SpawnProjectile()
    {
        StartCoroutine(SpawnProjectile(ray));
    }

    private IEnumerator SpawnProjectile(GameObject ray)
    {
        Spawn(ray);
        yield return new WaitForSeconds(cooldown);
        SpawnProjectile();
    }
}
