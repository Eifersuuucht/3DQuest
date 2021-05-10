using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour {

    [SerializeField]
    ParticleSystem ps;
    bool isPlayer;
    bool isCube;
    bool isPlaying;
    int layerMask;
    // Update is called once per frame
    void Start () {
        isPlayer = false;
        isCube = false;
        
        isPlaying = false;
    }

    void Update()
    {
        if(!isPlaying && (isPlayer || isCube))
        {
            ps.Play();
            isPlaying = true;
        }
        if(isPlaying && !isPlayer && !isCube)
        {
            ps.Stop();
            isPlaying = false;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayer = true;
        }
        if (other.gameObject.layer == 8)
        {
            isCube = true;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayer = false;
        }

        if (other.gameObject.layer == 8)
        {
            isCube = false;
        }
        
    }
}
