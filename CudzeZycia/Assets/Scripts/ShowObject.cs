using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObject : MonoBehaviour
{
    public CameraMovement lockcamera;
    public CharacterMovement lockmovement;
    public GameObject _ShowObject;
    private bool TurnObject = false;
    private bool isCollide = false;
    private int Many = 0;






    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Collider")
        {
            isCollide = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collider")
        {
            isCollide = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollide == true && Many == 0)
        {
            TurnObject = true;
            Instantiate(_ShowObject);
            Many = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isCollide == true)
        {
            TurnObject = false;
            Many = 0;
        }
    }




    private void FixedUpdate()
    {
        if (TurnObject == true)
        {
            lockcamera.enabled = false;
            lockmovement.enabled = false;
        }
        else if (TurnObject == false)
        {
            lockcamera.enabled = true;
            lockmovement.enabled = true;
        }
    }


}
