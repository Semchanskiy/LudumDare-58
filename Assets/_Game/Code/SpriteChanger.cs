using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpriteChanger : MonoBehaviour
{
    protected bool IsTic = false;
    protected List<Transform> _childrens;
    protected Transform _currentActiveChildren;

    protected void Awake()
    {
        _childrens = new List<Transform>();
        foreach (Transform child in transform)
        {
            _childrens.Add(child);
        }
    }

    protected virtual void Start()
    {
        
        OnEnableChildren(0);
        
        G.run.OnTic += () =>
        {
            G.run.OnTic += OnTicHandler;
        };
    }

    protected virtual void OnDestroy()
    {
        G.run.OnTic -= () =>
        {
            G.run.OnTic -= OnTicHandler;
        };
    }
    
    protected void OnTicHandler()
    {
        StartCoroutine(TicInvoke());
    }
    protected virtual IEnumerator TicInvoke()
    {
        if (IsTic) yield break;
        IsTic = true;
        
        switch (G.run.countThings)
        {
            case 0: yield return ZeroThing(); break;
            case 1: yield return FirstThing(); break;
            case 2: yield return SecondThing(); break;
            case 3: yield return ThirdThing(); break;
            case 4: yield return FourthThing(); break;
            case 5: yield return FifthThing(); break;
            case 6: yield return SixthThing(); break;
            case 7: yield return SeventhThing(); break;
        };
        IsTic = false;
    }
    
    protected virtual IEnumerator ZeroThing()
    {
        yield return null;
    }

    protected virtual IEnumerator FirstThing()
    {
        yield return null;
    }
    
    protected virtual IEnumerator SecondThing()
    {
        yield return null;
    }
    protected virtual IEnumerator ThirdThing()
    {
        yield return null;
    }
    protected virtual IEnumerator FourthThing()
    {
        yield return null;
    }
    protected virtual IEnumerator FifthThing()
    {
        yield return null;
    }
    protected virtual IEnumerator SixthThing()
    {
        yield return null;
    }
    
    protected virtual IEnumerator SeventhThing()
    {
        yield return null;
    }

    protected virtual IEnumerator GlitchChild(int index, float time = 0.15f)
    {
        int indexLastActiveChildren = GetIndexActiveChildren();
        
        OnEnableChildren(index);
        yield return new WaitForSeconds(time);
        OnEnableChildren(indexLastActiveChildren);
    }

    protected void OnEnableChildren(int index)
    {
        for (int i = 0; i < _childrens.Count; i++)
        {
            if (i==index)
            {
                _childrens[i].gameObject.SetActive(true);
                _currentActiveChildren = _childrens[i];
            }
            else
            {
                _childrens[i].gameObject.SetActive(false);
            }
        }
    }

    protected int GetIndexActiveChildren()
    {
        Debug.Log(_currentActiveChildren);
        for (int i = 0; i < _childrens.Count; i++)
        {
            if (_childrens[i] == _currentActiveChildren)
            {
                return i;
            }
        }
        Debug.LogError("Не найден дочерний объект по индексу");
        return 0;
    }
    
}
