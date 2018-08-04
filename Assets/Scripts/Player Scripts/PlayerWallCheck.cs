using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallCheck: WallCheck
{

    public PlayerController player;
    bool wallJumping;
    // Use this for initialization
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 8;
        //RayCast emitting horizontally from the attached object facing the direction they are moving or had last moved.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * (int)player.direction, distance, layerMask);

        //Wall Sliding
        if (hit.collider != null && player.GroundCheck.groundState != GroundState.Grounded)
        {

            player.isWallSlide = true;
            if (Input.GetButtonDown("Jump"))
            {
                //movement.outsideForce = true;
                player.direction = (Direction)(-(int)player.direction);
                player.rb.velocity = new Vector2(speed * (int)player.direction, speed * 2);
            }
        }
        else
        {
            player.isWallSlide = false;

            //player.rb.gravityScale = 2f;
        }


    }




    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * distance);

    }
}