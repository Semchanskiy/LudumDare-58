using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : UIPanel
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _settingsButton;
    private void OnEnable()
    {
        SettingsPanel.SetMixerVolume("Music", -60f);
        SettingsPanel.SetMixerVolume("SFX", -60f);
        //Time.timeScale = 0;
        G.run.IsPlay = false;
        _resumeButton.onClick.AddListener(() =>
        {
            G.ui.pausePanel.Hide();
        });
        _settingsButton.onClick.AddListener(() =>
        {
            G.ui.settingsPanel.Show();
        });
        _backButton.onClick.AddListener(() =>
        {
            G.ui.menuPanel.FastShow();
            SceneManager.LoadScene("Menu");
        });
    }
    
    private void OnDisable()
    {
        SettingsPanel.SetMixerVolume("Music", G.playerData.musicVolume);
        SettingsPanel.SetMixerVolume("SFX", G.playerData.SFXVolume);
        //Time.timeScale = 1;
        G.run.IsPlay = true;
        _resumeButton.onClick.RemoveListener(() =>
        {
            G.ui.pausePanel.Hide();
        });
        _settingsButton.onClick.RemoveListener(() =>
        {
            G.ui.settingsPanel.Show();
        });
        _backButton.onClick.RemoveListener(() =>
        {
            G.ui.menuPanel.FastShow();
            SceneManager.LoadScene("Menu");
        });
    }
}
