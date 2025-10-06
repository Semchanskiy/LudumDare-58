using UnityEngine;

public class MenuScreenChanger : MonoBehaviour
{
    [SerializeField] private GameObject _goodScreen;
    [SerializeField] private GameObject _badScreen;
    private float time = 10f;
    private float timer = 0f;
    void Start()
    {
        timer = Random.Range(3f,5f);
        _goodScreen.SetActive(true);
        _badScreen.SetActive(false);
    }

    private void OpenGoodScreen()
    {
        //G.audio.PlaySFX("Noise");
        timer = Random.Range(1f,10f);
        _goodScreen.SetActive(true);
        _badScreen.SetActive(false);
    }
    private void OpenBadScreen()
    {
        timer = Random.Range(0.1f,0.4f);
        G.audio.PlaySFX("Noise");
        _goodScreen.SetActive(false);
        _badScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_goodScreen.activeSelf == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                OpenBadScreen();
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                OpenGoodScreen();
            }
        }
    }
}
