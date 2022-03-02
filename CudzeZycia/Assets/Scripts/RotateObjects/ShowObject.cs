using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShowObject : MonoBehaviour
{
    public CinemachineVirtualCamera lockcamera;
    public CharacterMovement lockmovement;
    public GameObject _ShowObject;
    private bool TurnObject = false;
    private bool isCollide = false;
    private int Many = 0;
    private GameObject pasue;



    private void Start()
    {
        pasue = GameObject.Find("Pause");
    }


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
            PrzyblizObiekt();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isCollide == true)
        {
            ZamknijObiekt();
        }
    }


    void PrzyblizObiekt()
    {
        TurnObject = true;
        Instantiate(_ShowObject);
        Many = 1;
        Cursor.lockState = CursorLockMode.None;
        pasue.SetActive(false);
    }

    void ZamknijObiekt()
    {
        TurnObject = false;
        Many = 0;
        Cursor.lockState = CursorLockMode.Locked;
        pasue.SetActive(true);
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
