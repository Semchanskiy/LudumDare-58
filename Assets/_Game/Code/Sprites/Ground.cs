using System.Collections;
using UnityEngine;

public class Ground : SpriteChanger
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [Header("Colors")]

    [SerializeField] private Color _standartColor;
    [SerializeField] private Color _yellowColor;
    [SerializeField] private Color _browColor;
    [SerializeField] private Color _redColor;
    [SerializeField] private Color _grayColor;
    protected override IEnumerator ZeroThing()
    {
        yield return null;
    }

    protected override IEnumerator FirstThing()
    {
        yield return null;
    }
    protected override IEnumerator SecondThing()
    {
        _spriteRenderer.color = _yellowColor;
        yield return null;
    }
    
    protected override IEnumerator ThirdThing()
    {
        yield return null;
    }
    
    protected override IEnumerator FourthThing()
    {
        _spriteRenderer.color = _browColor;
        yield return null;
    }
    
    protected override IEnumerator FifthThing()
    {
        yield return null;
    }
    protected override IEnumerator SixthThing()
    {
        _spriteRenderer.color = _redColor;
        yield return null;
    }
}
