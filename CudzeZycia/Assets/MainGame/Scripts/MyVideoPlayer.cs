using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;

public class MyVideoPlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoTexture;

    private bool skipAll = false;

    void Start()
    {
        // domy�lnie ukryj video
        if (videoTexture.activeSelf){videoTexture.SetActive(false);}
    }

    public async Task PlayVideo(VideoClip videoClip)
    {
        videoPlayer.Stop();

        videoPlayer.clip = videoClip;
        videoTexture.SetActive(true);
        videoPlayer.Play();

        Time.timeScale = 0; // pause game

        var delayms = Convert.ToInt32(Math.Ceiling(videoClip.length * 1000));

        while (delayms > 0)
        {
            await Task.Delay(100);
            delayms -= 100;
            if (skipAll) { break; }
        }

        Time.timeScale = 1; // run game
        videoTexture.SetActive(false);
    }


    public void Debug_Skip_On()
    {
        skipAll = true;
    }

    public void Debug_Skip_Off()
    {
        skipAll = false;
    }

}
