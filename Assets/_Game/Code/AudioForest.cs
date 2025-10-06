using System.Collections;
using UnityEngine;

public class AudioForest : MonoBehaviour
{
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (G.run)
        {
            G.run.OnChangeCountThings += (stage) =>
            {
                ChangeThings(stage);
            };
        }
    }
    

    private void OnDestroy()
    {
        if (G.run)
        {
            G.run.OnChangeCountThings -= (stage) =>
            {
                ChangeThings(stage);
            };
        }
    }
    
    private void ChangeThings(int i)
    {
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

    protected IEnumerator ZeroThing()
    {
        yield return null;
    }
    protected IEnumerator FirstThing()
    {
        yield return null;
    }
    
    protected IEnumerator SecondThing()
    {
        yield return null;
    }
    protected IEnumerator ThirdThing()
    {
        
        yield return null;
    }
    protected IEnumerator FourthThing()
    {
        _audioSource.Stop();
        yield return null;
    }
    protected IEnumerator FifthThing()
    {
        yield return null;
    }
    protected IEnumerator SixthThing()
    {
        yield return null;
    }
    
    protected IEnumerator SeventhThing()
    {
        yield return null;
    }
}
