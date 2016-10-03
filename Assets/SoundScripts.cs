using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundScripts : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource volumeAudio;
    public void VolumeController()
    {
        volumeAudio.volume = volumeSlider.value;
    }
}