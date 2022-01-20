using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public VectorValue Storage;
    public Animator anim;
    void Start()
    {
        Storage.trans = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Storage.trans == true)
        {
            anim.SetBool("Start", true);
        }
    }
}
