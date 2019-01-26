﻿using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer pieceOfShield;

    // Use this for initialization
    void Start()
    {
        GenerateShield();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateShield()
    {
        float h = pieceOfShield.sprite.rect.height;
        float w = pieceOfShield.sprite.rect.width;
        float b = w;
        float a = Mathf.Sqrt(h*h + w*w);
        float angle = Mathf.Acos((2 * a * a - b * b) / (2 * a * a));
        Debug.Log($"{a} {b} {angle}");
        for (int i = 0; i < 2 * Mathf.PI / angle; i++)
        {
            Transform piece = Instantiate(pieceOfShield).transform;
            piece.position = transform.position;
            piece.Rotate(new Vector3(0, 0, Mathf.Rad2Deg * i * angle));
        }
    }
}
