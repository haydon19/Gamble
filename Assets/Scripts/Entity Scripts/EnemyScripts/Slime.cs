using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
public class Slime : EnemyBehaviour {

    protected MovementComponent moveComponent;
    GroundCheck groundCheck;
    WallCheck wallCheck;
    public float turnTime = 1f;
    public float timer = 0;

    [SerializeField]
    bool checkForExit = false;
    float exitTimer;

    [SerializeField]
    float exitTime;
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
        if (knockback)
            return;

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

        if(checkForExit)
        {
            if (exitTimer > 0)
            {
                exitTimer -= Time.deltaTime;
            } else
            {
                checkForExit = false;
            }
        }

        if (moveComponent.Direction < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
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

    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "PlayerAttack")
        {
            print("Hit by player!");
            //Hit from the right.
            if ((int)moveComponent.Direction < 0)
            {
                rb.velocity = new Vector2(10, 5);
                print("Hit from left.");
            }
            //Hit from the left or equal.
            else
            {
                //print("Hit from right.");

                rb.velocity = new Vector2(-10, 5);
            }
            checkForExit = true;
            exitTimer = exitTime;
        }

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (checkForExit)
            {
                knockback = true;
                checkForExit = false;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            knockback = false;
        }
    }

}
