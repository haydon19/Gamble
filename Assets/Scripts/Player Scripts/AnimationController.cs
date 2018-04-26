using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {


    //Need access to PlayerController Functions to know what the player is doing.
    GameObject player = GameObject.Find("Player");

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void getWalkingAnimations()
    {
        //float x = player.GetComponent<PlayerController>().
        if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (x != 0)
        {
            isWalking = true;
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            isWalking = false;
            GetComponent<Animator>().SetBool("isWalking", false);
        }
        return x;
    }


}
