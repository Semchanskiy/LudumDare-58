using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPanel : UIPanel
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingButton;

    private void OnEnable()
    {
        _settingButton.onClick.AddListener(() =>
        {
            G.ui.settingsPanel.Show();
        });
        _startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
        });
    }

    private void OnDisable()
    {
        _settingButton.onClick.RemoveListener(() =>
        {
            G.ui.settingsPanel.Show();
        });
        _startButton.onClick.RemoveListener(() =>
        {
            SceneManager.LoadScene("Game");
        });
    }
}
