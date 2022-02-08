using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite chest_open;
    public Sprite chest_closed;
    public int goldAmount;
    
    /*
    protected override void OnCollide(Collider2D coll)
    {
        Debug.Log("Chest (me) collided with " + coll.name);
    }
    */
    //change sprite to closed on start

    protected override void OnCollect()
    {
        //Debug.Log("Chest at OnCollect");
        if (!collected)
        {
            collected = true;
            //change game component sprite to empty chest
            GetComponent<SpriteRenderer>().sprite = chest_open;
            //eventually this will actually give gold
            Debug.Log("Give " + goldAmount + " gold.");
        }
    }
}
