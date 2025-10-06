using UnityEngine;
using UnityEngine.UI;

public class PausePanel : UIPanel
{
    [SerializeField] private Button _backButton;
    private void OnEnable()
    {
        SettingsPanel.SetMixerVolume("Music", -60f);
        SettingsPanel.SetMixerVolume("SFX", -60f);
        //Time.timeScale = 0;
        G.run.IsPlay = false;
        _backButton.onClick.AddListener(() =>
        {
            G.ui.pausePanel.Hide();
            
        });
    }
    
    private void OnDisable()
    {
        SettingsPanel.SetMixerVolume("Music", G.playerData.musicVolume);
        SettingsPanel.SetMixerVolume("SFX", G.playerData.SFXVolume);
        //Time.timeScale = 1;
        G.run.IsPlay = true;
        _backButton.onClick.RemoveListener(() =>
        {
            G.ui.pausePanel.Hide();
        });
    }
}
