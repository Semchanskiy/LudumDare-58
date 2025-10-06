using System.Collections;
using UnityEngine;

public class AudioMusicBG : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]private AudioClip _clip2;
    [SerializeField]private AudioClip _clip3;
    [SerializeField]private AudioClip _clip4;
    [SerializeField]private AudioClip _clip5;
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

    public void StartMusic()
    {
        _audioSource.Play();
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
        _audioSource.clip =_clip2;
        _audioSource.Play();
        yield return null;
    }
    protected IEnumerator ThirdThing()
    {
        _audioSource.clip =_clip3;
        _audioSource.Play();
        yield return null;
    }
    protected IEnumerator FourthThing()
    {
        _audioSource.clip =_clip4;
        _audioSource.Play();
        yield return null;
    }
    protected IEnumerator FifthThing()
    {
        _audioSource.clip =_clip5;
        _audioSource.Play();
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
