// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Audio;

// public class SaveAudioSettings : MonoBehaviour
// {
//     public Slider masterSlider;
//     public Slider musicSlider;
//     public Slider effectsSlider;

//     public AudioMixer masterMixer;

//     private void Start()
//     {
//         // Load saved settings at the start
//         masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
//         musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
//         effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 1f);

//         ApplyAudioSettings();
//     }

//     public void SaveAndApplySettings()
//     {
//         // Save settings to PlayerPrefs
//         PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
//         PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
//         PlayerPrefs.SetFloat("EffectsVolume", effectsSlider.value);
//         PlayerPrefs.Save();

//         // Apply the audio settings
//         ApplyAudioSettings();
//     }

//     private void ApplyAudioSettings()
//     {
//         // Convert the slider value (0 to 1) to decibel value (-80dB to 0dB)
//         float masterVolume = Mathf.Lerp(-80f, 0f, masterSlider.value);
//         float musicVolume = Mathf.Lerp(-80f, 0f, musicSlider.value);
//         float effectsVolume = Mathf.Lerp(-80f, 0f, effectsSlider.value);

//         masterMixer.SetFloat("Master", masterVolume);
//         masterMixer.SetFloat("Music", musicVolume);
//         masterMixer.SetFloat("Effects", effectsVolume);
//     }
// }
