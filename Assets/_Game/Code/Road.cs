using System.Collections;
using UnityEngine;

public class Road : SpriteChanger
{
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
        yield return base.ThirdThing();
    }
    protected virtual IEnumerator FourthThing()
    {
        yield return base.FourthThing();
    }
    protected virtual IEnumerator FifthThing()
    {
        yield return base.FifthThing();
        EnableChildrenForIndex(1);
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
}
