using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMoveLeft : MonoBehaviour
{
    public float LeftSpeed = 10f
        ;
    
   

    private void FixedUpdate()
    {
        transform.position += new Vector3(-LeftSpeed*Time.deltaTime, 0, 0);
    }
}
