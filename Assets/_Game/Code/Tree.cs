using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tree : SpriteChanger
{
    protected override void Awake()
    {
        
    }

    void Start()
    {
        G.run.OnTic += () =>
        {
            StartCoroutine(TicInvoke());
        };
    }

    private void OnDestroy()
    {
        G.run.OnTic -= () =>
        {
            StartCoroutine(TicInvoke());
        };
    }
    
    void Update()
    {
        
    }


    private IEnumerator TicInvoke()
    {
        if (IsTic) yield break;
        IsTic = true;
        
        switch (G.run.countThings)
        {
            case 0:
                break;
            case 1:
                if (Random.Range(0, 100) < 10)
                {
                    _spriteRenderer.sprite = _blackSprite;
                    yield return new WaitForSeconds(0.2f);
                    _spriteRenderer.sprite = _standartSprite;
                }
                
                break;
        };
        IsTic = false;
    }
        
}
