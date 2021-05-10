using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMainTheme : MonoBehaviour {

    public void PlayTheme()
    {
        if(!FindObjectOfType<AudioManager>().IsPlaying("MainTheme"))
            FindObjectOfType<AudioManager>().Play("MainTheme");
        if (FindObjectOfType<AudioManager>().IsPlaying("LevelTheme"))
            FindObjectOfType<AudioManager>().Stop("LevelTheme");
        if (FindObjectOfType<AudioManager>().IsPlaying("Ambient"))
            FindObjectOfType<AudioManager>().Stop("Ambient");
        if(gameObject.name == "Intro")
            gameObject.SetActive(false);
    }
}
