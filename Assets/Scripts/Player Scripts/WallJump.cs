using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour {

    public PlayerController player;
    public float distance = 1f;
    public float speed = 2f;
    bool wallJumping;
    // Use this for initialization
    void Start() {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
        void Update() {
        int layerMask = 1 << 8;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * (int)player.direction, distance, layerMask);
        
        //Wall Sliding
        if(hit.collider != null)
        {
            print("Hit collider " + hit.collider.name);
            
            //player.rb.gravityScale = 1.0f;
            if (Input.GetAxis("LHorizontal") == (int)player.direction)
            {
                player.rb.velocity = new Vector2(0, -1.5f);
            }

            if (Input.GetButtonDown("Jump"))
            {

                print("getting there");
                //movement.outsideForce = true;
                player.direction = (Direction)(-(int)player.direction);

                player.rb.velocity = new Vector2(speed * (int)player.direction, speed);

                 



            }
        } else
        {
            //player.rb.gravityScale = 2f;
        }


    }
         

    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * (int)player.direction * distance);

    }
}
