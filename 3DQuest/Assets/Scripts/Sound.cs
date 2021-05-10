using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound{

    public string name;
    public AudioClip clip;
    public string group;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
   
    [HideInInspector]
    public bool isPlayed = false;

    [HideInInspector]
    public AudioSource source;
}
