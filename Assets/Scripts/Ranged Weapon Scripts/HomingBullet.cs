using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Projectile
{
    Transform target;
    Vector2 upTarget;
    bool homing = false;
    // Use this for initialization
     void Start () {
        rb = GetComponent<Rigidbody2D>();
        upTarget = transform.position + new Vector3(0, 6, 0);
    }

    public void Init(Transform t)
    {
        target = t;
    }
    // Update is called once per frame
    public override void Update () {

        if (reflected)
        {
            base.Update();
            return;
        }

        float step;


        if (!homing)
        {
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, upTarget, step);
            if (Vector2.Distance(transform.position, upTarget) < 1)
            {
                homing = true;
            }
        } else
        {
            step = speed * 4 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
