using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    bool blokada = false;
    public GameObject pasueobject;


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

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        blokada = false;
        pasueobject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
