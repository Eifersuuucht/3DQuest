using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningWithTorches : MonoBehaviour {


    [SerializeField]
    ParticleSystem ps1;
    [SerializeField]
    ParticleSystem ps2;
    [SerializeField]
    Animator an;
    [SerializeField]
    GameObject fButton;
    bool isPlayedBoth;
    bool isOpened;
    float timer = 0f;
    int seconds = 0;

    void Start()
    {
        isPlayedBoth = false;
        isOpened = false;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.F)  && isPlayedBoth && !isOpened)
        {
            an.SetTrigger("Open");
            isOpened = true;
            fButton.SetActive(false);
           
        }

        if(isOpened && seconds < 5)
        {
            timer += Time.fixedDeltaTime;
            seconds = (int)timer % 60;
        }
        else if(seconds >= 5)
        {
            an.SetTrigger("Close");
            isOpened = false;
            seconds = 0;
            timer = 0f;
            
        }

    }
    void OnTriggerStay()
    {
        if(ps1.isPlaying  && ps2 == null || ps1.isPlaying && ps2.isPlaying)
        { 
            isPlayedBoth = true;
            if (!isOpened)
            {
                fButton.SetActive(true);
            }
            
        }
    }

    void OnTriggerExit()
    {
        isPlayedBoth = false;
        fButton.SetActive(false);
    }

    public void PlayDoorOpen()
    {
        FindObjectOfType<AudioManager>().Play("DoorOpen");
    }

    public void PlayDoorClose()
    {
        FindObjectOfType<AudioManager>().Play("DoorClose");
    }
}
