using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShowObject : MonoBehaviour
{
    private CinemachineVirtualCamera lockcamera;
    private CharacterMovement lockmovement;
    private GameObject _outline;
    public GameObject _ShowObject;
    private bool TurnObject = false;
    private bool isCollide = false;
    private int Many = 0;
    private GameObject pasue;



    private void Start()
    {
        pasue = GameObject.Find("Pause");
        lockmovement = GameObject.Find("Character").GetComponent<CharacterMovement>();
        lockcamera = GameObject.Find("Camera").GetComponent<CinemachineVirtualCamera>();
        _outline = transform.Find("outline").gameObject;
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Collider")
        {
            isCollide = true;
            _outline.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collider")
        {
            isCollide = false;
            _outline.SetActive(false);
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
        lockcamera.enabled = false;
        lockmovement.enabled = false;
        Instantiate(_ShowObject);
        Many = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pasue.SetActive(false);
    }

    void ZamknijObiekt()
    {
        lockcamera.enabled = true;
        lockmovement.enabled = true;
        Many = 0;
        Cursor.lockState = CursorLockMode.Locked;
        pasue.SetActive(true);
        Cursor.visible = false;
    }

}
