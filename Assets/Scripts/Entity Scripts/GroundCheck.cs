using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Class emits a RayCast downward from the attached object and checks whether or not it is colliding with anything.
 *  If it is, 1: the object is grounded
 *  else      2: the object is airborne*/

public enum GroundState { Grounded, Airborn };


public class GroundCheck : MonoBehaviour {


    public float distance = 1f;
    [SerializeField]
    Vector3 offsetFront;
    [SerializeField]
    Vector3 offsetBack;
    public GroundState groundState = GroundState.Grounded;
    [SerializeField]
    LayerMask layerMask;

    public RaycastHit2D hitFront;
    public RaycastHit2D hitBack;
    // Use this for initialization
    void Start () {

    }

    void Update()
    {
        //int layerMask = 1 << 8;
        //Vector Emitting downward from attached object
        hitFront = Physics2D.Raycast(transform.position + offsetFront, -1* transform.up, distance, layerMask);
        hitBack = Physics2D.Raycast(transform.position + offsetBack, -1 * transform.up, distance, layerMask);

        //Object is grounded if collider is activated.
        if (hitFront.collider != null || hitBack.collider)
        {
            groundState = GroundState.Grounded;

        }
        //Otherwise we are in the airborn.
        else
        {
            groundState = GroundState.Airborn;

        }


    }
    //Color the RayCast for visibility in Unity
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position+offsetBack, transform.position + offsetBack + -1*transform.up * distance);
        Gizmos.DrawLine(transform.position + offsetFront, transform.position + offsetFront + -1 * transform.up * distance);


    }
}
