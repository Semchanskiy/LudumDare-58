using System.Collections;
using UnityEngine;

public class Lake : SpriteChanger
{
        
    protected override IEnumerator FirstThing()
    {
        yield return base.FirstThing();
        yield return null;
    }
    protected override IEnumerator SecondThing()
    {
        yield return base.SecondThing();
        EnableChildrenForIndex(1);
        yield return null;
    }
    
    protected override IEnumerator ThirdThing()
    {
        yield return base.ThirdThing();
        yield return null;
    }
    
    protected override IEnumerator FourthThing()
    {
        yield return base.FourthThing();
        EnableChildrenForIndex(2);
        yield return null;
    }
    
    protected override IEnumerator FifthThing()
    {
        yield return base.FifthThing();
        yield return null;
    }
}
