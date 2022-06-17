using UnityEngine;


public class PlayMusic : MonoBehaviour
{
    [StringInList(typeof(PropertyDrawersHelper), "AllSongNames")]
    public string songName;

    public bool isAmbientOrBackgroundSong = true;

    void Start()
    {
        if (isAmbientOrBackgroundSong)
        {
            FindObjectOfType<AudioManager>().PlayAsBackground(songName);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play(songName);
        }
    }
}
