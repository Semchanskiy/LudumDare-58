using System.Collections;
using UnityEngine;

public class Road : SpriteChanger
{
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
        yield return base.SecondThing();
        yield return null;
    }
    protected override IEnumerator ThirdThing()
    {
        yield return base.ThirdThing();
    }
    protected override IEnumerator FourthThing()
    {
        yield return base.FourthThing();
    }
    protected override IEnumerator FifthThing()
    {
        yield return base.FifthThing();
        
        EnableChildrenForIndex(1);
        yield return null;
    }
    protected override IEnumerator SixthThing()
    {
        yield return null;
    }
    
    protected override IEnumerator SeventhThing()
    {
        yield return null;
    }
}
