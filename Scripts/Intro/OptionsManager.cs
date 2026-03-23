using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    [Header("Brightness")]
    [SerializeField] private Image blackOverlay;
    [SerializeField] private Slider brightnessSlider;

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 1f);
        float brightness = PlayerPrefs.GetFloat("Brightness", 1f);

        volumeSlider.value = volume;
        brightnessSlider.value = brightness;

        ApplyVolume(volume);
        ApplyBrightness(brightness);

        volumeSlider.onValueChanged.AddListener(ApplyVolume);
        brightnessSlider.onValueChanged.AddListener(ApplyBrightness);
    }

    private void ApplyVolume(float value)
    {
        float db = value <= 0.001f ? -80f : Mathf.Log10(value) * 20f;
        audioMixer.SetFloat("BG_Music", db);

        PlayerPrefs.SetFloat("Volume", value);
    }

    private void ApplyBrightness(float value)
    {
        Color c = blackOverlay.color;
        c.a = 1f - value;
        blackOverlay.color = c;

        PlayerPrefs.SetFloat("Brightness", value);
    }
}