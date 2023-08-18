using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Audio;
using UnityEngine.UI;

public class tmp : MonoBehaviour
{
   public Slider volSlider;
   // public Slider MusicSlider;
   // public Slider EffectSlider;
   public AudioMixer masterMixer;
   public void AudioControl()
   {
      float sound = Mathf.Lerp(-80, 0, volSlider.value);
      masterMixer.SetFloat("Master", sound);
   }  
   // public void MusicAudioControl()
   // {
   //    float soundMusic = Mathf.Lerp(-80, 0, MusicSlider.value);
   //    masterMixer.SetFloat("Music", soundMusic);
   // }  
   // public void EffectAudioControl()
   // {
   //    float soundEffect = Mathf.Lerp(-80, 0, EffectSlider.value);
   //    masterMixer.SetFloat("Effect", soundEffect);
   // }  
   
      
   public void Start() {
      
   }
}
