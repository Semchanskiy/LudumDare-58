using System;
using UnityEngine;
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
    }

    private void OnDisable()
    {
        _settingButton.onClick.RemoveListener(() =>
        {
            G.ui.settingsPanel.Show();
        });
    }
}
