using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider soundsSlider;
    public Slider ambientSlider;

    //in order sliders to save their values throught the game
    public static float masterVolume = 0f;
    public static float musicVolume = 0f;
    public static float soundsVolume = 0f;
    public static float ambientVolume = 0f;
    
    void Awake()
    {
        masterSlider.value = masterVolume;
        musicSlider.value = musicVolume;
        soundsSlider.value = soundsVolume;
        ambientSlider.value = ambientVolume;
    }
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);//setting the volume
        masterVolume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("volumeMusic", volume);
        musicVolume = volume;
    }

    public void SetSoundsVolume(float volume)
    {
        audioMixer.SetFloat("volumeSounds", volume);
        soundsVolume = volume;
    }

    public void SetAmbientVolume(float volume)
    {
        audioMixer.SetFloat("volumeAmbient", volume);
        ambientVolume = volume;
    }
}
