using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 input = new Vector3(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical"), 0.0f);
        //angle is used to determine the angle in which the right analog stick is being held
        var angle = Mathf.Atan2(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical")) * Mathf.Rad2Deg - 90;
        //print("Angle: " + angle);
        if (angle <= -90)
        {
            //print("Less than 90, and GREATER THAN -90");
            transform.rotation = Quaternion.Euler(0, 180f,0);
        }
        else
        {

            //Rotate the animation for the gun on the Y-axis
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
