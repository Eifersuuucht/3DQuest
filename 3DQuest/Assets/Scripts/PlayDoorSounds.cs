using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDoorSounds : MonoBehaviour {

    public void PlayDoorOpen()
    {
        FindObjectOfType<AudioManager>().Play("DoorOpen");
    }

    public void PlayDoorClose()
    {
        FindObjectOfType<AudioManager>().Play("DoorClose");
    }
}
