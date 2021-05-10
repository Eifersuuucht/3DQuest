using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlay : MonoBehaviour {
    public void TeleportOutPlay()
    {
        FindObjectOfType<AudioManager>().Play("TeleportOut");
    }

    public void LevelThemePlay()
    {
        if (FindObjectOfType<AudioManager>().IsPlaying("MainTheme"))
        {
            FindObjectOfType<AudioManager>().Stop("MainTheme");
        }

        if (!FindObjectOfType<AudioManager>().IsPlaying("LevelTheme"))
        {
            FindObjectOfType<AudioManager>().Play("LevelTheme");
        }

        if (!FindObjectOfType<AudioManager>().IsPlaying("Ambient"))
        {
            FindObjectOfType<AudioManager>().Play("Ambient");
        }
    }
}
