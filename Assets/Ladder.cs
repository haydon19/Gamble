using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    [SerializeField]
    float climbSpeed = 5;

    public float ClimbSpeed
    {
        get
        {
            return climbSpeed;
        }

        set
        {
            climbSpeed = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}



}
