using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorObject : MonoBehaviour
{
    private MaterialPropertyBlock _mat;
    private Renderer _renderer;
    public GenerateRandomNumbers GRN;
    public bool boots, pants, chest, hair = false;
    void Start()
    {
        _mat = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();


        _renderer.GetPropertyBlock(_mat);


        if (boots == true)
        {
            _mat.SetFloat("_RandomColor", GRN.BootsColor);
            _mat.SetFloat("_RandomMultiply", GRN.BootsColorMultiply);
        }
        else if (pants == true)
        {
            _mat.SetFloat("_RandomColor", GRN.PantsColor);
            _mat.SetFloat("_RandomMultiply", GRN.PantsColorMultiply);
        }
        else if (chest == true)
        {
            _mat.SetFloat("_RandomColor", GRN.ChestColor);
            _mat.SetFloat("_RandomMultiply", GRN.ChestColorMultiply);
        }
        else if (hair == true)
        {
            _mat.SetFloat("_RandomColor", GRN.HairColor);
            _mat.SetFloat("_RandomMultiply", GRN.HairColorMultiply);
        }

        _renderer.SetPropertyBlock(_mat);
    }

    
}
