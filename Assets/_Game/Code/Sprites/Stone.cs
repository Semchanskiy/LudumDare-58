using System.Collections;
using UnityEngine;

public class Stone : SpriteChanger
{
    protected override IEnumerator FirstThing()
    {
        yield return base.FirstThing();
        yield return null;
    }
    protected override IEnumerator SecondThing()
    {
        yield return base.SecondThing();
        if (Random.Range(0, 100) < 20)
        {
            EnableChildrenForIndex(1);
        }
        yield return null;
    }
    
    protected override IEnumerator ThirdThing()
    {
        yield return base.ThirdThing();
        if (Random.Range(0, 100) < 20)
        {
            EnableChildrenForIndex(2);
        }
        yield return null;
    }
    
    protected override IEnumerator FourthThing()
    {
        yield return base.FourthThing();
        yield return null;
    }
    
    protected override IEnumerator FifthThing()
    {
        yield return base.FifthThing();
        if (Random.Range(0, 100) < 40)
        {
            EnableChildrenForIndex(2);
        }
        yield return null;
    }
    protected override IEnumerator SixthThing()
    {
        yield return base.SixthThing();
        if (Random.Range(0, 100) < 100)
        {
            yield return GlitchChild(1);
        }
        while (G.run.countThings==6)
        {
            if (Random.Range(0, 100) < 40)
            {
                yield return GlitchChild(2);
            }

            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }

    protected override IEnumerator SeventhThing()
    {
        yield return base.SeventhThing();
        if (Random.Range(0, 100) < 60)
        {
            EnableChildrenForIndex(2);
        }
        yield return null;
    }
}
