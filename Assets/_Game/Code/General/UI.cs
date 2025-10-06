using System;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public UIPanel menuPanel;
    public UIPanel settingsPanel;
    public UIPanel pausePanel;
    public UIPanel losePanel;
    public UIPanel winPanel;
    public UIPanel screemerPanel;
    //public GamePanel GamePanel;
    
    private static UI _instance;

    private void Awake()
    {
        if (_instance == null || _instance == this)
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

    public void Init()
    {
        if (_instance == null|| _instance == this)
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
