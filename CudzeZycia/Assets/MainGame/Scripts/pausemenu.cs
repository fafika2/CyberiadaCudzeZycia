using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    private FirstPersonLook lockcamera;
    private FirstPersonMovement lockmovement;
    bool blokada = false;
    public GameObject pasueobject; // canvas with pause menu (resume btn, close game, etc)

    private void Start()
    {
        lockmovement = GameObject.Find("Character").GetComponent<FirstPersonMovement>();
        lockcamera = GameObject.Find("Camera").GetComponent<FirstPersonLook>();
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape) && blokada == true)
        {
            ResumeGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && blokada == false)
        {
            PasueGame();
        }
    }


    void PasueGame()
    {
        Time.timeScale = 0;
        blokada = true;
        pasueobject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        lockcamera.enabled = false;
        lockmovement.enabled = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        blokada = false;
        pasueobject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lockcamera.enabled = true;
        lockmovement.enabled = true;
    }
}
