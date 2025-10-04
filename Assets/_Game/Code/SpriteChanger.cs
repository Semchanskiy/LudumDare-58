using System.Collections;
using UnityEngine;

public abstract class SpriteChanger: MonoBehaviour
{
    protected bool IsTic = false;
    protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected Sprite _standartSprite;
    [SerializeField] protected Sprite _blackSprite;
    protected virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected virtual IEnumerator TicInvoke()
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
    
    public virtual IEnumerator ZeroThing()
    {
        yield return null;
    }

    public virtual IEnumerator FirstThing()
    {
        yield return null;
    }
    
    public virtual IEnumerator SecondThing()
    {
        yield return null;
    }
    public virtual IEnumerator ThirdThing()
    {
        yield return null;
    }
    public virtual IEnumerator FourthThing()
    {
        yield return null;
    }
    public virtual IEnumerator FifthThing()
    {
        yield return null;
    }
    public virtual IEnumerator SixthThing()
    {
        yield return null;
    }
    
    public virtual IEnumerator SeventhThing()
    {
        yield return null;
    }
    
}
