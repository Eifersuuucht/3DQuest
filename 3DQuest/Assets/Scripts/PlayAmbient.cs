using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAmbient : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().Play("Ambient");
	}
	
	
}
