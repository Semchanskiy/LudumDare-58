using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ForestTree : SpriteChanger
{
    
    // protected override IEnumerator TicInvoke()
    // {
    //     yield return base.TicInvoke();
    // }
        
    protected override IEnumerator FirstThing()
    {
        yield return base.FirstThing();
        if (Random.Range(0, 100) < 20)
        {
            EnableChildrenForIndex(1);
        }

        yield return null;
    }
    protected override IEnumerator SecondThing()
    {
        yield return base.SecondThing();
        if (Random.Range(0, 100) < 30)
        {
            EnableChildrenForIndex(1);
        }

        yield return null;
    }
    
    protected override IEnumerator ThirdThing()
    {
        yield return base.ThirdThing();
        if (Random.Range(0, 100) < 50)
        {
            EnableChildrenForIndex(1);
        }
        if (Random.Range(0, 100) < 15)
        {
            EnableChildrenForIndex(2);
        }

        while (G.run.countThings==3)
        {
            if (Random.Range(0, 100) < 5)
            {
                yield return GlitchChild(3);
            }

            yield return new WaitForSeconds(1f);
        }

        yield return null;
    }
    
    protected override IEnumerator FourthThing()
    {
        yield return base.FourthThing();
        while (G.run.countThings==4)
        {
            if (Random.Range(0, 100) < 5)
            {
                yield return GlitchChild(3);
            }

            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }
    
    protected override IEnumerator FifthThing()
    {
        yield return base.FifthThing();
        if (Random.Range(0, 100) < 90)
        {
            EnableChildrenForIndex(1);
        }
        if (Random.Range(0, 100) < 75)
        {
            EnableChildrenForIndex(2);
        }
        if (Random.Range(0, 100) < 14)
        {
            EnableChildrenForIndex(3);
        }
        
        
        while (G.run.countThings==5)
        {
            if (Random.Range(0, 100) < 20)
            {
                yield return GlitchChild(3);
            }

            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }
    protected override IEnumerator SixthThing()
    {
        yield return base.SixthThing();
        if (Random.Range(0, 100) < 100)
        {
            EnableChildrenForIndex(2);
        }
        if (Random.Range(0, 100) < 35)
        {
            EnableChildrenForIndex(3);
        }
        
        while (G.run.countThings==5)
        {
            if (Random.Range(0, 100) < 40)
            {
                yield return GlitchChild(3);
            }

            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }
    
    // protected override IEnumerator FirstThing()
    // {
    //     while (G.run.countThings == 1)
    //     {
    //         yield return new WaitForSeconds(1f);
    //         
    //         if (Random.Range(0, 100) < 5)
    //         {
    //             yield return GlitchChild(1);
    //         }
    //     }
    // }
}
