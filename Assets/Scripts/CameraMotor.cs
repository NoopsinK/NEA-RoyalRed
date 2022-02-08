using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    //put focus on a thing - namely the player
    public Transform lookAt;
    //how far the player can move b4 the camera moves
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    // Update is called once per frame
    //Lateupdate is called after update and fixed update
    //ie camera needs to be moved last, avoids v-sync issues
    void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        //transform is where the camera currently is
        float deltaX = lookAt.position.x - transform.position.x;
        float deltaY = lookAt.position.y - transform.position.y;

        //if player is outside camera bounds (rectangle)
        if (deltaX > boundX || deltaX < -boundX)
        {
            //player is to the >
            if(transform.position.x < lookAt.position.x)
            {
                //add to deltaX
                delta.x = deltaX - boundX;
            }
            //player is to the <
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        if (deltaY > boundY || deltaY < -boundY)
        {
            //player is to the >
            if (transform.position.y < lookAt.position.y)
            {
                //add to deltaX
                delta.y = deltaY - boundY;
            }
            //player is to the <
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        //finally, move the camera
        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
