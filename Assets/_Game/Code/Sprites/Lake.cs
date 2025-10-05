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
        EnableChildrenForIndex(1);
        yield return null;
    }
    
    protected override IEnumerator FourthThing()
    {
        yield return base.FourthThing();
        EnableChildrenForIndex(2);
        while (G.run.countThings==4)
        {
            if (Random.Range(0, 100) < 40)
            {
                yield return GlitchChild(4);
            }

            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }
    
    protected override IEnumerator FifthThing()
    {
        yield return base.FifthThing();
        EnableChildrenForIndex(3);
        while (G.run.countThings==5)
        {
            if (Random.Range(0, 100) < 40)
            {
                yield return GlitchChild(4);
            }

            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }
    protected override IEnumerator SixthThing()
    {
        yield return base.SixthThing();
        EnableChildrenForIndex(4);
        yield return null;
    }
    protected override IEnumerator SeventhThing()
    {
        yield return base.SeventhThing();
        yield return null;
    }
}
