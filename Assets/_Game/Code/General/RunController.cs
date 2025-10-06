using System;
using UnityEngine;

public class RunController : MonoBehaviour
{
    [SerializeField] private AudioMusicBG _musicBg;
    private float TicTime = 1f;
    private float Timer = 0f;
    public bool IsPlay = false;
    
    public Action<int> OnChangeCountThings;
    private int _countThings;
    public GameObject Player;

    public int countThings
    {
        get
        {
            return _countThings;
        }
        set
        {
            _countThings = value;
            OnChangeCountThings?.Invoke(_countThings);
        }
    }
    private void Awake()
    {
        G.run = this;
        if (G.ui)
        {
            G.ui.menuPanel.FastClose();
            G.ui.settingsPanel.FastClose();
            G.ui.losePanel.FastClose();
            G.ui.pausePanel.FastClose();
            G.ui.winPanel.FastClose();
        }
    }
    void Start()
    {
        
    }

    public void StartGame()
    {
        IsPlay = true;
        _musicBg.StartMusic();
    }
    
    void Update()
    {
         
        if (IsPlay)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                G.ui.pausePanel.Show();
            }
        }
    }

    public void CollectItem()
    {
        countThings++;
    }
}
