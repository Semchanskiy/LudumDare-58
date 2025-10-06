using System;
using UnityEngine;

public class RunController : MonoBehaviour
{
    public Action OnTic;
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
        }
    }
    void Start()
    {
        IsPlay = true;
    }
    
    void Update()
    {
         
        if (IsPlay)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                G.ui.pausePanel.Show();
            }
            Timer += Time.deltaTime;
            if (Timer >= TicTime)
            {
                Timer = 0;
                OnTic?.Invoke();
            }
        }
    }

    public void CollectItem()
    {
        countThings++;
    }
}
