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
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            if (Input.GetButtonDown("Jump"))
            {

                print("getting there");
                //movement.outsideForce = true;
                player.direction = (Direction)(-(int)player.direction);

                GetComponent<Rigidbody2D>().velocity = new Vector2(speed * (int)player.direction, speed/2);

                 



            }
        }


    }
         

    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * (int)player.direction * distance);

    }
}
