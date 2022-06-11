using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public float maxTime, minTime;
    private float _timer = 0.0f;
    public GameObject _GO;
    private bool IsVisible = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Spawner")
        {
            if(IsVisible == false)
            SpawnNPC();
        }
    }

    void Update()
    {
        _timer -= Time.deltaTime;
    }
    void SpawnNPC()
    {
        if(_timer > 0)
        {
            return;
        }

        _timer = Random.Range(minTime, maxTime);
        Instantiate(_GO, transform.position, transform.rotation);
    }

    private void OnBecameVisible()
    {
        IsVisible = true;
    }

    private void OnBecameInvisible()
    {
        IsVisible = false;
    }

}
