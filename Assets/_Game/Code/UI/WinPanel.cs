using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : UIPanel
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        G.run.IsPlay = false;
        StartCoroutine(Win());
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(10f);
        G.ui.menuPanel.FastShow();
        SceneManager.LoadScene("Menu");
    }

    private void OnDisable()
    {

    }
}
