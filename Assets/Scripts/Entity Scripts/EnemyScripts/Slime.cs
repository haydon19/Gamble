using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyBehaviour {

    public float fireRate = 1;
    public float fireTime = 0;
    public float turnTime = 1f;
    public float timer = 0;
    // Use this for initialization
    public override void Start () {
        base.Start();
        turnTime = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update () {
        CheckForTarget();


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
            moveComponent.MoveHorizontal(dir);
        

        if (target != null)
        {
            fireTime += Time.deltaTime;
            //Shoot
            if (fireTime >= fireRate)
            {
            GetComponent<RangedAttack>().Shoot(target.transform);


                fireTime = 0;
            }

        }
    }
}
