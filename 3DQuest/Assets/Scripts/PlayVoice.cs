using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoice : MonoBehaviour {

    [SerializeField]
    string nameOfTheRecord;
    static string nameOfThePlayingRecord;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !FindObjectOfType<AudioManager>().IsPlayed(nameOfTheRecord))
        {
            if(nameOfThePlayingRecord != null && nameOfThePlayingRecord != nameOfTheRecord)
            {
                FindObjectOfType<AudioManager>().Stop(nameOfThePlayingRecord);
                FindObjectOfType<AudioManager>().Play(nameOfTheRecord);
                nameOfThePlayingRecord = nameOfTheRecord;
            }
            else
            {
                FindObjectOfType<AudioManager>().Play(nameOfTheRecord);
                nameOfThePlayingRecord = nameOfTheRecord;
            }
        }
    }

}
