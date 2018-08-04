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
    public float speed = 2f;
    [SerializeField]
    bool isWall;

    // Use this for initialization
    void Start() {
        movement = GetComponent<MovementComponent>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
        void Update() {
        int layerMask = 1 << 8;
        //RayCast emitting horizontally from the attached object facing the direction they are moving or had last moved.
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.25f, 0), (Vector3.right * (int)movement.Direction) + new Vector3(0, -0.25f, 0), distance, layerMask);


        if (hit)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            isWall = true;
        } else
        {
            isWall = false;

        }


    }

    public bool IsWall()
    {
        return isWall;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position + new Vector3(0,-0.25f,0), transform.position + Vector3.right * distance + new Vector3(0, -0.25f, 0) );

    }
}
