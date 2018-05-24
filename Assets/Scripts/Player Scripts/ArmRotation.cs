using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {
    public PlayerController player;
	// Use this for initialization
	void Start () {
        player = GetComponentInParent<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
        //Shows sprite with pistol out
        if (player.playerState == PlayerState.RangedAttack)
        {
            //armRotation.SetActive(true);
            //input is used to read the direction of the right analog stick
            Vector3 input = new Vector3(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical"), 0.0f);
            //angle is used to determine the angle in which the right analog stick is being held
            var angle = Mathf.Atan2(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical")) * Mathf.Rad2Deg - 90;
            print("Angle: " + angle);


                //Rotate Player when aiming behind
                //print("THIS HAPPENED! Player should be facing left.");
                //Rotate the animation for the gun on the Z-axis
                transform.rotation = Quaternion.Euler(0, 0, angle);
            
        }
        else
        {
            //armRotation.SetActive(false);
        }
    }
}
