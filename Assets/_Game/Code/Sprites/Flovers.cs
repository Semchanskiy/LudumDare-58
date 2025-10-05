using System.Collections;
using UnityEngine;

public class Flovers : SpriteChanger
{
    
    protected override IEnumerator FirstThing()
    {
        yield return base.FirstThing();
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
        yield return null;
    }
    
    protected override IEnumerator FourthThing()
    {
        Destroy(gameObject);
        yield return null;
    }
}
