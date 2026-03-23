using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSound3 : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);

        volumeSlider.SetValueWithoutNotify(savedVolume);

        ApplyVolume(savedVolume);

        volumeSlider.onValueChanged.AddListener(ApplyVolume);
    }

    private void ApplyVolume(float value)
    {
        float db = value <= 0.001f ? -80f : Mathf.Log10(value) * 20f;

        audioMixer.SetFloat("Game03", db);

        PlayerPrefs.SetFloat("Volume", value);
    }
}
