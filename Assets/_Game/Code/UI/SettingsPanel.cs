using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsPanel : UIPanel
{
    [SerializeField] private Button _backButton;
    
    private const float MinVolume = -80f;
    private const float MaxVolume = 0f;
    
    [Header("Sound Sliders")] 
    [SerializeField] private Slider _musicAudio;
    [SerializeField] private Slider _sfxAudio;
    private void OnEnable()
    {
        _musicAudio.onValueChanged.AddListener(ChangeMusicAudio);
        _sfxAudio.onValueChanged.AddListener(ChangeSFXAudio);
        _backButton.onClick.AddListener(() =>
        {
            G.ui.settingsPanel.Hide();
        });
        
        LoadVolumeSettings();
    }
    
    private void OnDisable()
    {
        _musicAudio.onValueChanged.RemoveListener(ChangeMusicAudio);
        _sfxAudio.onValueChanged.RemoveListener(ChangeSFXAudio);
        _backButton.onClick.RemoveListener(() =>
        {
            G.ui.settingsPanel.Hide();
        });
    }
    
    private void ChangeMusicAudio(float value)
    {
        SetMixerVolume("Music", value);
        G.playerData.musicVolume = value;
    }

    private void ChangeSFXAudio(float value)
    {
        SetMixerVolume("SFX", value);
        G.playerData.SFXVolume = value;
    }
    
    public static void SetMixerVolume(string parameterName, float normalizedValue)
    {
        float volume = Mathf.Lerp(MinVolume, MaxVolume, normalizedValue);

        if (normalizedValue <= 0.01f)
            volume = -80f;
        else
            volume = Mathf.Log10(normalizedValue) * 20;
        
        G.main.audioMixerGroup.audioMixer.SetFloat(parameterName, volume);
    }
    
    public void LoadVolumeSettings()
    {
        _musicAudio.value = G.playerData.musicVolume;
        _sfxAudio.value = G.playerData.SFXVolume;
    }
}
