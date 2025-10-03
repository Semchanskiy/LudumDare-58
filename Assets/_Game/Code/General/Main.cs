using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public AudioMixerGroup audioMixerGroup;
    [Header("Systems")] 
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private UI _ui;
    
    public static Main Instance;
    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            G.main = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    

    private void Start()
    {
        InitApp();
    }

    private void InitApp()
    {
        _playerData.Init();
        _audioManager.Init();
        _ui.Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SplashScreen");
        }
    }
}
