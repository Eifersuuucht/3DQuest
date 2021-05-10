using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public AudioMixerGroup audmixgr;
    public AudioMixerGroup MusicMixer;
    public AudioMixerGroup SoundsMixer;
    public AudioMixerGroup AmbientMixer;

    public static AudioManager instance;

    // Use this for initialization
    void Awake ()
    {
       if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

		foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            switch (s.group)
            {
                case "Music": s.source.outputAudioMixerGroup = MusicMixer; break;
                case "Sounds": s.source.outputAudioMixerGroup = SoundsMixer; break;
                case "Ambient": s.source.outputAudioMixerGroup = AmbientMixer; break;
            }
        }
	}
	
	public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
        s.isPlayed = true;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }

    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return false;
        return s.source.isPlaying;
    }

    public bool IsPlayed(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return false;
        return s.isPlayed;
    }

}
