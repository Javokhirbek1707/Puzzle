using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSound1 : MonoBehaviour
{
    [SerializeField] 
    private AudioMixer _audioMixer;
    [SerializeField] 
    private Slider _volumeSlider;

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);

        _volumeSlider.SetValueWithoutNotify(savedVolume);

        ApplyVolume(savedVolume);

        _volumeSlider.onValueChanged.AddListener(ApplyVolume);
    }

    private void ApplyVolume(float value)
    {
        float db = value <= 0.001f ? -80f : Mathf.Log10(value) * 20f;

        _audioMixer.SetFloat("Game01", db);

        PlayerPrefs.SetFloat("Volume", value);
    }
}