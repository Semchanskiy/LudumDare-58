using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class SpriteChanger : MonoBehaviour
{
    protected bool IsTic = false;
    protected List<ChildrenObject> _childrens;
    protected ChildrenObject _currentActiveChildren;

    protected void Awake()
    {
        _childrens = new List<ChildrenObject>();
        foreach (Transform child in transform)
        {
            if (child.GetComponent<ChildrenObject>() != null)
            {
                _childrens.Add(child.GetComponent<ChildrenObject>());
            }
        }
            
    }

    protected virtual void Start()
    {
        
        EnableChildrenForIndex(0);
        
        // G.run.OnTic += () =>
        // {
        //     G.run.OnTic += OnTicHandler;
        // };

        G.run.OnChangeCountThings += (i) =>
        {
            ChangeThings(i);
        };
    }

    protected virtual void OnDestroy()
    {
        // G.run.OnTic -= () =>
        // {
        //     G.run.OnTic -= OnTicHandler;
        // };
        
        G.run.OnChangeCountThings -= (i) =>
        {
            ChangeThings(i);
        };
    }

    protected void ChangeThings(int i)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeThingsInvoke());
    }

    protected virtual IEnumerator ChangeThingsInvoke()
    {
        
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
    }
    // protected void OnTicHandler()
    // {
    //     //StartCoroutine(TicInvoke());
    // }
    // protected virtual IEnumerator TicInvoke()
    // {
    //     if (IsTic) yield break;
    //     IsTic = true;
    //     
    //     switch (G.run.countThings)
    //     {
    //         case 0: yield return ZeroThing(); break;
    //         case 1: yield return FirstThing(); break;
    //         case 2: yield return SecondThing(); break;
    //         case 3: yield return ThirdThing(); break;
    //         case 4: yield return FourthThing(); break;
    //         case 5: yield return FifthThing(); break;
    //         case 6: yield return SixthThing(); break;
    //         case 7: yield return SeventhThing(); break;
    //     };
    //     IsTic = false;
    // }
    
    protected virtual IEnumerator ZeroThing()
    {
        yield return null;
    }

    protected virtual IEnumerator FirstThing()
    {
        yield return RandomGlitch(2);
    }
    
    protected virtual IEnumerator SecondThing()
    {
        yield return RandomGlitch(2);
    }
    protected virtual IEnumerator ThirdThing()
    {
        yield return RandomGlitch(2);
    }
    protected virtual IEnumerator FourthThing()
    {
        yield return RandomGlitch(2);
    }
    protected virtual IEnumerator FifthThing()
    {
        yield return RandomGlitch(3);
    }
    protected virtual IEnumerator SixthThing()
    {
        yield return RandomGlitch(3);
    }
    
    protected virtual IEnumerator SeventhThing()
    {
        yield return RandomGlitch(4);
    }

    protected virtual IEnumerator GlitchChild(int index, float time = 0.15f)
    {
        int indexLastActiveChildren = GetIndexActiveChildren();
        
        EnableChildrenForIndex(index);
        yield return new WaitForSeconds(time);
        EnableChildrenForIndex(indexLastActiveChildren);
    }

    protected void EnableChildrenForIndex(int index)
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

    protected IEnumerator RandomGlitch(int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return GlitchChild(Random.Range(0, _childrens.Count));
            yield return new WaitForSeconds(Random.Range(0f, 1f));
            
        }
    }
}
