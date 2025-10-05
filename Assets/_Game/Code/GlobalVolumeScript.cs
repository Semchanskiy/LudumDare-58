using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalVolumeScript : MonoBehaviour
{
    [SerializeField] private Volume volume;

    
    private void Start()
    {
        
        G.run.OnChangeCountThings += (i) =>
        {
            ChangeThings(i);
        };
    }
    

    protected virtual void OnDestroy()
    {
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
    
    protected virtual IEnumerator ZeroThing()
    {
        yield return null;
    }

    protected virtual IEnumerator FirstThing()
    {
        if (volume.profile.TryGet(out FilmGrain r))
        {
            r.intensity.value = 0.05f;
        }
        yield return null;
    }
    
    protected virtual IEnumerator SecondThing()
    {
        if (volume.profile.TryGet(out FilmGrain r))
        {
            r.intensity.value = 0.1f;
        }
        yield return null;
    }
    protected virtual IEnumerator ThirdThing()
    {
        if (volume.profile.TryGet(out FilmGrain r))
        {
            r.intensity.value = 0.2f;
        }
        yield return null;
    }
    protected virtual IEnumerator FourthThing()
    {
        if (volume.profile.TryGet(out FilmGrain r))
        {
            r.intensity.value = 0.3f;
        }
        yield return null;
    }
    protected virtual IEnumerator FifthThing()
    {
        if (volume.profile.TryGet(out FilmGrain r))
        {
            r.intensity.value = 0.4f;
        }
        yield return null;
    }
    protected virtual IEnumerator SixthThing()
    {
        if (volume.profile.TryGet(out FilmGrain r))
        {
            r.intensity.value = 0.5f;
        }
        if (volume.profile.TryGet(out ChromaticAberration c))
        {
            c.intensity.value = 1f;
        }
        yield return null;
    }
    
    protected virtual IEnumerator SeventhThing()
    {
        if (volume.profile.TryGet(out FilmGrain r))
        {
            r.intensity.value = 0.7f;
        }
        yield return null;
    }
}
