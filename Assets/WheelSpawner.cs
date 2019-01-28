using UnityEngine;
using System.Collections.Generic;

public class WheelSpawner : MonoBehaviour
{
    [SerializeField]
    private int parts = 16;
    
    private List<Vector2> available;
    private List<Vector2> used;

    private System.Random random;

    private void Start()
    {
        available = new List<Vector2>();
        used = new List<Vector2>();
        random = new System.Random();

        GenerateParts();
    }

    private void GenerateParts()
    {
        for (int i = 0; i < parts; i++)
        {
            var angle = i * 2 * Mathf.PI / parts;
            available.Add(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)));
        }
    }

    public Vector2 getVector()
    {
        if (available.Count == 0)
            return Vector2.zero;
        var v = available[random.Next(available.Count)];
        available.Remove(v);
        used.Add(v);
        return v;
    }

    /** make point available again */
    public void freeVector(Vector2 vec)
    {
        if (used.Contains(vec))
        {
            used.Remove(vec);
            available.Add(vec);
        }
        else
        {
            //throw new System.Exception("WTF??? " + vec);
        }
    }
}
