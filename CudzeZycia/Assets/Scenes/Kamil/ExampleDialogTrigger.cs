using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.DialogSystem;

public class ExampleDialogTrigger : MonoBehaviour
{
    public SphereCollider triggerSphereCollider; // z tego gameobject do ktorego jest przypisany
    public Canvas DialogCanvas; // gameobject (canvas) ktory ma Dialog Window

    private DialogWindow dialogWindowScript;

    void Start()
    {
        triggerSphereCollider.isTrigger = true;
        DialogCanvas.gameObject.SetActive(false);
        dialogWindowScript = DialogCanvas.GetComponent<DialogWindow>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Open dialog");
        DialogCanvas.gameObject.SetActive(true);
        dialogWindowScript.Setup();

        // todo: ustawianie jaki dialog ma siê wyœwietlaæ
        // dialogWindowScript.activeDialog 
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Close dialog.");
        DialogCanvas.gameObject.SetActive(false);
    }
}
