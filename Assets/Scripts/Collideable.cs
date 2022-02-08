using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Require: BoxCollider2D]
public class Collideable : MonoBehaviour
{
    //public variables can be set in unity editor
    //filter the objects we collide with
    public ContactFilter2D filter; //should this be public?
    private BoxCollider2D boxCollider;
    //an array of what was hit each frame (max)
    private Collider2D[] hits = new Collider2D[10];

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //get boxcollider component
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //every collision

        //overlap collider takes in contact filter and
        //an array to store the results
        boxCollider.OverlapCollider(filter, hits); 
        //error: ^ object reference not set to an instance of an object??

        //check everything we've collided with
        for (int i = 0; i < hits.Length; i++)
        {
            //if nothing has been hit
            if (hits[i] == null)
            {
                continue;
            }

            //for now, just log the object we've hit to the console
            OnCollide(hits[i]);
            //once we've dealt with the hit, clear it from the array
            hits[i] = null;
        }

    }
    //virtual collider function that can be overridden by children
    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log("I've hit " + coll.name);
    }
}
