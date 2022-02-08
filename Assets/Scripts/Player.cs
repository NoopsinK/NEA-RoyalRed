using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    //to keep track of the movement vector
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    // Start is called before the first frame update
    private void Start()
    {
        //get boxcollider component 
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    //using physics and manual collision detection, so fixedUpdate instead of update
    //rare bug where it might skip inputs
    private void FixedUpdate()
    {
        //get keypresses 
        //returns 0 if no keys are pressed, returns 1 if a/d or </> are pressed
        float x = Input.GetAxisRaw("Horizontal");
        //returns 0 if no keys are pressed, returns 1 if w/s or ^/v are pressed
        float y = Input.GetAxisRaw("Vertical");

        //reset movedelta
        moveDelta = new Vector3(x, y, 0);

        /*
        Debug.Log(x);
        Debug.Log(y);
        */

        //swap sprite direction
        if (moveDelta.x > 0)
        {
            //facing right
            transform.localScale = Vector3.one;
        } else if (moveDelta.x < 0)
        {
            //facing left
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //cast a box in the place to move to first, if the box returns null, then
        //we are allowed to move

        //X
        hit = Physics2D.BoxCast(transform.position,
            boxCollider.size, 0,
            new Vector2(moveDelta.x, 0),
            Mathf.Abs(moveDelta.x * Time.deltaTime),
            LayerMask.GetMask("Actor", "Blocking"));
        //if nothing is hit, we are allowed to  move

        //MOVEMENT based on movement vector (moveDelta)
        //using deltaTime so older/slower computers aren't at a disadvantage
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

        //Y
        hit = Physics2D.BoxCast(transform.position,
            boxCollider.size, 0,
            new Vector2(0, moveDelta.y),
            Mathf.Abs(moveDelta.y * Time.deltaTime),
            LayerMask.GetMask("Actor", "Blocking"));
        //if nothing is hit, we are allowed to  move
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        
    }
}
