using UnityEngine;
using UnityEngine.UI;

public class PausePanel : UIPanel
{
    [SerializeField] private Button _backButton;
    private void OnEnable()
    {
        //Time.timeScale = 0;
        G.run.IsPlay = false;
        _backButton.onClick.AddListener(() =>
        {
            G.ui.pausePanel.Hide();
            
        });
    }
    
    private void OnDisable()
    {
        //Time.timeScale = 1;
        G.run.IsPlay = true;
        _backButton.onClick.RemoveListener(() =>
        {
            G.ui.pausePanel.Hide();
        });
    }
}
