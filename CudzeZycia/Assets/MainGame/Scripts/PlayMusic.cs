using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public string songName;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play(songName);
    }
}
