using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPart : Collectable
{
    protected virtual override void OnCollect()
    {
        collected = true;
    }
}
