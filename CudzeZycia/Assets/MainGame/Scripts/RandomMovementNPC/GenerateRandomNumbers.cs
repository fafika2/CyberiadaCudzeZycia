using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomNumbers : MonoBehaviour
{
    public float BootsColor, BootsColorMultiply, ChestColor, ChestColorMultiply, PantsColor, PantsColorMultiply, HairColor, HairColorMultiply = 0f;
    void Start()
    {
        BootsColor = Random.Range(0.0f, 1.0f);
        BootsColorMultiply = Random.Range(0.5f, 1.0f);
        ChestColor = Random.Range(0.0f, 1.0f);
        ChestColorMultiply = Random.Range(0.5f, 1.0f);
        PantsColor = Random.Range(0.0f, 1.0f);
        PantsColorMultiply = Random.Range(0.5f, 1.0f);
        HairColor = Random.Range(0.0f, 1.0f);
        HairColorMultiply = Random.Range(0.5f, 1.0f);
    }

 
}
