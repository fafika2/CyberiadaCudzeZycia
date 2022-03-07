using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
