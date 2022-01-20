using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionDoors : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 playerPosition;
    public VectorValue playerStorage;

    int EClick = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            EClick = 1;
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            EClick = 0;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Collider") && EClick == 1)
        {
            StartCoroutine(sceneLoader());
        }
    }

    IEnumerator sceneLoader()
    {
        playerStorage.trans = true;
        playerStorage.initialValue = playerPosition;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneToLoad);
    }

}
