using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour {

    PlayerController player;
    Animator animator;
    SpriteRenderer spriteRenderer;
    //Need access to PlayerController Functions to know what the player is doing.
    public GameObject armRotation;
    
    // Use this for initialization
    void Start () {
        player = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetInteger("PlayerState", (int)player.playerState);
        if(player.rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        } else if(player.rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);

        }

        //Shows sprite with pistol out
        if(player.playerState == PlayerState.RangedAttack)
        {
            armRotation.SetActive(true);
            //input is used to read the direction of the right analog stick
            Vector3 input = new Vector3(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical"), 0.0f);
            //angle is used to determine the angle in which the right analog stick is being held
            var angle = Mathf.Atan2(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical")) * Mathf.Rad2Deg -90;
            print("Angle: " + angle);
            if (angle <= -90)
            {
                //print("Less than 90, and GREATER THAN -90");
                armRotation.transform.rotation = Quaternion.Euler(0, 0, angle);
                transform.rotation = Quaternion.Euler(0, 180f, 0);

            }
            else
            {
                //Rotate Player when aiming behind
                //print("THIS HAPPENED! Player should be facing left.");
                transform.rotation = Quaternion.Euler(0, 0, 0);
                //Rotate the animation for the gun on the Y-axis
                armRotation.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
        else
        {
            armRotation.SetActive(false);
        }
    }

    
}
