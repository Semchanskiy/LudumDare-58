using System;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public UIPanel menuPanel;
    public UIPanel settingsPanel;
    public UIPanel pausePanel;
    public GameObject SelectLevelPanel;
    public GameObject LiderboardPanel;
    public GameObject WinPanel;
    public GameObject LosePanel;
    //public GamePanel GamePanel;
    
    private static UI _instance;
    public void Init()
    {
        if (_instance == null)
        {
            _instance = this;
            G.ui = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // MenuPanel.SetActive(true);
        // SelectLevelPanel.SetActive(false);
        // LiderboardPanel.SetActive(false);
        // WinPanel.SetActive(false);
        // LosePanel.SetActive(false);
        // PausePanel.SetActive(false);
        //GamePanel.gameObject.SetActive(false);
    }
}
