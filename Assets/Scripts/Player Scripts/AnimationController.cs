using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour {

    PlayerController player;
    Animator animator;
    //Need access to PlayerController Functions to know what the player is doing.

    // Use this for initialization
    void Start () {
        player = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetInteger("PlayerState", (int)player.playerState);
	}
    
}
