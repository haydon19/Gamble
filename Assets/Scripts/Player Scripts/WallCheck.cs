﻿using System.Collections;
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
    [SerializeField]
    bool isWall;
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    LayerMask layerMask;

    public bool IsWall
    {
        get
        {
            return isWall;
        }

        set
        {
            isWall = value;
        }
    }

    // Use this for initialization
    void Start() {
        movement = GetComponent<MovementComponent>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
        void Update() {

        //RayCast emitting horizontally from the attached object facing the direction they are moving or had last moved.
        RaycastHit2D hit = Physics2D.Raycast(transform.position + offset, (Vector3.right * (int)movement.Direction), distance, layerMask);

        if (hit)
        {
            Debug.Log(gameObject.tag + " sees " + hit.collider.tag);

            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            IsWall = true;

        } else
        {
            IsWall = false;


        }


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position + offset, transform.position + offset + (Vector3.right * distance));

    }
}
