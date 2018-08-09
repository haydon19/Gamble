﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
public class Slime : Enemy {

    GroundCheck groundCheck;
    WallCheck wallCheck;
    public float turnTime = 1f;
    public float timer = 0;

    // Use this for initialization
    public override void Start () {
        base.Start();
        turnTime = Random.Range(1, 5);
        moveComponent = GetComponent<MovementComponent>();
        groundCheck = groundCheck = GetComponent<GroundCheck>();
        wallCheck = GetComponent<WallCheck>();
    }


    private void FixedUpdate()
    {

        if (enemySight.target != null)
        {
            
            HasTargetBehaviour();
        }
        else
        {
            NoTargetBehaviour();
        }

    }


    // Update is called once per frame
    void Update () {


        if (moveComponent.Direction < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
            GetComponentInChildren<Canvas>().transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            GetComponentInChildren<Canvas>().transform.localScale = new Vector3(1, 1, 1);
        }




    }

    void NoTargetBehaviour()
    {

        if (timer < turnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            moveComponent.Direction = (Direction)((int)moveComponent.Direction * -1);

        }

        if (groundCheck.groundState == GroundState.Grounded && !wallCheck.IsWall)
            moveComponent.MoveHorizontal((int)moveComponent.Direction * 3);
    }

    void HasTargetBehaviour()
    {

        if (enemySight.target.position.x < transform.position.x)
        {
            moveComponent.Direction = Direction.Left;
        }
        else
        {
            moveComponent.Direction = Direction.Right;
        }
        //Shoot
        if (enemySight.CheckLineOfSight())
        {
            GetComponent<RangedAttack>().Shoot(enemySight.target);

        } else
        {
            MoveToTarget();
        }

        
    }

    void MoveToTarget()
    {
        

        moveComponent.MoveHorizontal((int)moveComponent.Direction * 3);
    }

    //There was problems with this in the genereal enemy code, due to the fact that the Turret was an enemy but didnt have a rigidbody
    //To fix this, we should either give enemies a collision manager, and then different types can managed their own types of collisions
    //or we seperate the enemies into collidable and non-collidable


}
