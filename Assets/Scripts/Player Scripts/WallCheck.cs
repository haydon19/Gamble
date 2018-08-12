using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Emits a RayCast horizontally from the attached object and checks whether it is colliding with anything.
 * If it is, 1. Player wallSliding is set to true
 *              -> If "Jump" key is pressed, flip players direction, and player jumps in that direction.
 * Else,     2. Player wallSliding is false
 */ 
public class WallCheck : MonoBehaviour {

    public float distance = 1f;
    Rigidbody2D rb;
    MovementComponent movement;
    [SerializeField]
    bool isWall;
    [SerializeField]
    Vector3 offsetMiddle;
    [SerializeField]
    Vector3 offsetTop;
    [SerializeField]
    Vector3 offsetBottom;
    [SerializeField]
    LayerMask layerMask;

    public bool IsWall
    {
        get
        {
            return isWall;
        }

        set
        {
            isWall = value;
        }
    }

    // Use this for initialization
    void Start() {
        movement = GetComponent<MovementComponent>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
        void Update() {

        //RayCast emitting horizontally from the attached object facing the direction they are moving or had last moved.
        RaycastHit2D hitTop = Physics2D.Raycast(transform.position + offsetTop, (Vector3.right * (int)movement.Direction), distance, layerMask);
        //RayCast emitting horizontally from the attached object facing the direction they are moving or had last moved.
        RaycastHit2D hitBot = Physics2D.Raycast(transform.position + offsetBottom, (Vector3.right * (int)movement.Direction), distance, layerMask);

        if (hitTop || hitBot)
        {


            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            IsWall = true;

        } else
        {
            IsWall = false;


        }


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position + offsetTop, transform.position + offsetTop + (Vector3.right * distance));
        Gizmos.DrawLine(transform.position + offsetBottom, transform.position + offsetBottom + (Vector3.right * distance));


    }
}
