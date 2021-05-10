using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SwordCutscene : MonoBehaviour {

	PlayableDirector timeline;
    [SerializeField]
    GameObject stone;
    [SerializeField]
    GameObject fButton;
    bool notPlayed;
    [SerializeField]
    Material matDissolve;
    float value;
    bool canPlay;
    bool waiting;
    float timer;
    int seconds;
    // Use this for initialization
    void Start () {
        timeline = GetComponent<PlayableDirector>();
        notPlayed = true;
        value = -1f;
        canPlay = false;
        matDissolve.SetFloat("Vector1_A2133333", -1);
        timer = 0f;
        seconds = 0;
        waiting = false;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(value < 1 && canPlay)
        {
            matDissolve.SetFloat("Vector1_A2133333", value);
            value += 0.01f;
        }
        if (waiting && seconds < 4)
        {
            timer += Time.fixedDeltaTime;
            seconds = (int)timer % 60;
        }
        else if (seconds >= 4)
        {
            waiting = false;
            canPlay = true;
            seconds = 0;
            timer = 0f;
        }

        if(value >= 0.99f)
        {
            stone.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if(notPlayed && obj.gameObject.tag == "Player")
        {
            fButton.SetActive(true);
        }
    }

    void OnTriggerStay(Collider obj)
    {
        if(notPlayed && obj.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.F))
            {
                timeline.Play();
                FindObjectOfType<AudioManager>().Play("SwordRotation");
                notPlayed = false;
                fButton.SetActive(false);
                waiting = true;
            }
        } 
    }

    void OnTriggerExit(Collider obj)
    {
        if (notPlayed && obj.gameObject.tag == "Player")
        {
            fButton.SetActive(false);
        }
    }
}
