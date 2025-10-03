using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private float _musicVolume;
    public float musicVolume
    {
        get
        {
            return _musicVolume;
        }
        set
        {
            _musicVolume = value;
            PlayerPrefs.SetFloat("MusicVolume", _musicVolume);
        }
    }
    
    private float _SFXVolume;
    public float SFXVolume
    {
        get
        {
            return _SFXVolume;
        }
        set
        {
            _SFXVolume = value;
            PlayerPrefs.SetFloat("SFXVolume", _SFXVolume);
        }
    }
    

    public void Init()
    {
        G.playerData = this;
        LoadData();
    }
    private void LoadData()
    {
        
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        //SettingsPanel.SetMixerVolume("Music", _musicVolume);
        //SettingsPanel.SetMixerVolume("SFX", _SFXVolume);
        
        float volume = Mathf.Lerp(-80f, 0f, SFXVolume);

        if (SFXVolume <= 0.01f)
            volume = -80f;
        else
            volume = Mathf.Log10(SFXVolume) * 20;
        
        G.main.audioMixerGroup.audioMixer.SetFloat("SFX", volume);
        
        float volume2 = Mathf.Lerp(-80f, 0f, musicVolume);

        if (musicVolume <= 0.01f)
            volume2 = -80f;
        else
            volume2 = Mathf.Log10(musicVolume) * 20;
        
        G.main.audioMixerGroup.audioMixer.SetFloat("Music", volume2);
    }
    
}
