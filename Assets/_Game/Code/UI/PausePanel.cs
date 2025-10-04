using UnityEngine;
using UnityEngine.UI;

public class PausePanel : UIPanel
{
    [SerializeField] private Button _backButton;
    private void OnEnable()
    {
        Time.timeScale = 0;
        _backButton.onClick.AddListener(() =>
        {
            G.ui.pausePanel.Hide();
        });
    }
    
    private void OnDisable()
    {
        Time.timeScale = 1;
        _backButton.onClick.RemoveListener(() =>
        {
            G.ui.pausePanel.Hide();
        });
    }
}
