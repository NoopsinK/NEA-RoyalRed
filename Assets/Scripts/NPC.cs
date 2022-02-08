using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Collideable
{
    public string speech;
    protected override void OnCollide(Collider2D coll)
    {
        
        Debug.Log("To " + coll.name + ": \"" + speech + "\"");
    }
}
