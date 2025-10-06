using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : UIPanel
{
    [SerializeField] private Button _restartButton;
    private void OnEnable()
    {
        G.run.IsPlay = false;
        //Time.timeScale = 0;
        _restartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.sceneCount);
        });
    }
    
    private void OnDisable()
    {
        //Time.timeScale = 1;
        
        _restartButton.onClick.RemoveListener(() =>
        {
            SceneManager.LoadScene(SceneManager.sceneCount);
        });
    }
}
