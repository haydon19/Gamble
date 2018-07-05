using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
public class Slime : EnemyBehaviour {

    protected MovementComponent moveComponent;
    public float fireRate = 1;
    public float fireTime = 0;
    public float turnTime = 1f;
    public float timer = 0;
    // Use this for initialization
    public override void Start () {
        base.Start();
        turnTime = Random.Range(1, 5);
        moveComponent = GetComponent<MovementComponent>();
    }

    // Update is called once per frame
    void Update () {

        //Look for a target
        enemySight.CheckForTarget();


        if (timer < turnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            dir *= -1;
            if (dir < 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            knockback = false;
        }

        if (!knockback)
            moveComponent.MoveHorizontal(dir*3);
        

        if (enemySight.target != null)
        {
            fireTime += Time.deltaTime;
            //Shoot
            if (fireTime >= fireRate)
            {
            GetComponent<RangedAttack>().Shoot(enemySight.target);


                fireTime = 0;
            }

        }
    }

    //There was problems with this in the genereal enemy code, due to the fact that the Turret was an enemy but didnt have a rigidbody
    //To fix this, we should either give enemies a collision manager, and then different types can managed their own types of collisions
    //or we seperate the enemies into collidable and non-collidable

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            print("Hit by player!");
            //Hit from the right.
            if (collision.transform.position.x < transform.position.x)
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
            knockback = true;
        }
    }
}
