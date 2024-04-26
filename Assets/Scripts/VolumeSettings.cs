/* Christian Kuykendall
 * Date:
 * Purpose:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//This script applies the audio to the audio slider in the options canvas
public class VolumeSettings : MonoBehaviour
{
    // Audio mixer
    [SerializeField] private AudioMixer audioMix;
    // Options menu slider
    [SerializeField] private Slider musicSlider;

    
    // This start fuction allows the slider and audio become compatible
    private void Start()
    {
        
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }

    public void SetMusicVolume()
    {
        // Sets volume to the value of what the slider is set to in the options menu
        float volume = musicSlider.value;
        // Uses the volume from the slider and applies it to the Master group which was renamed to 'music'
        // Music is logarithmic and the slider is a linear scale so Mathf.Log10 is applied to match the linear scale to the logarithmic one
        audioMix.SetFloat("music", Mathf.Lerp(-80f, 0f, volume));

        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    // Saves the players volume settings
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");

        SetMusicVolume();
    }

}

// I used the youtube video below for guidance
// https://www.youtube.com/watch?v=G-JUp8AMEx0