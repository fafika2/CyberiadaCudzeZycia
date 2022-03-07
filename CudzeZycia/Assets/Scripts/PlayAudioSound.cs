using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioSound : MonoBehaviour
{
    private AudioSource Player;
    void Start()
    {
        Player = GetComponent<AudioSource>();
    }

    void StepFootTurnOn()
    {
        Player.pitch = Random.Range(0.9f, 1.1f);
        Player.volume = Random.Range(0.4f, 0.6f);
        Player.Play();
    }
}
