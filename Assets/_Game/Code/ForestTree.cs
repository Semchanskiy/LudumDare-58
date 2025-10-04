using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ForestTree : SpriteChanger
{
    
    protected override IEnumerator TicInvoke()
    {
        yield return base.TicInvoke();
    }
        
    protected override IEnumerator FirstThing()
    {
        if (Random.Range(0, 100) < 10)
        {
            yield return GlitchChild(1);
        }
    }
}
