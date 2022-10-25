using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeSliderBehaviour : MonoBehaviour
{
    [SerializeField]
    private Slider MasterVolumeSlider;
    [SerializeField]
    private Text VolumeText;

    private void Awake()
    {
        //set the slider to the current volume
        MasterVolumeSlider.value = AudioListener.volume * 100;
        VolumeText.text = MasterVolumeSlider.value.ToString() + "%";
    }

    public void OnSliderValueChanged()
    {
        AudioListener.volume = MasterVolumeSlider.value/100;
        VolumeText.text = MasterVolumeSlider.value.ToString() + "%";
    }
}
