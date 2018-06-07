using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Class emits a RayCast downward from the attached object and checks whether or not it is colliding with anything.
 *  If it is, 1: the object is grounded
 *  else      2: the object is airborne*/

public class GroundCheck : MonoBehaviour {


    public PlayerController player;
    public float distance = 1f;
    bool grounded;

    // Use this for initialization
    void Start () {
        player = GetComponent<PlayerController>();

    }

    void Update()
    {
        int layerMask = 1 << 8;
        //Vector Emitting downward from attached object
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -1*Vector2.up, distance, layerMask);

        //Object is grounded if collider is activated.
        if (hit.collider != null)
        {
            player.groundState = GroundState.Grounded;

        }
        //Otherwise we are in the airborn.
        else
        {
            player.groundState = GroundState.Airborn;

        }


    }
    //Color the RayCast for visibility in Unity
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + -1*Vector3.up * distance);

    }
}
