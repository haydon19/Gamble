using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy {

    float timeCounter = 0;

    public float speed;
    public float width;
    public float height;
    public float foundWidth, foundHeight;


    bool hadTarget = false;

    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update () {

        timeCounter += Time.deltaTime * speed;

        float xWave = 0, yWave = 0;


        if (enemySight.target != null && enemySight.CheckLineOfSight())
        {

            GetComponent<RangedAttack>().Shoot(enemySight.target);
            xWave = (Mathf.Cos(timeCounter) * foundWidth);
            yWave = (Mathf.Sin(timeCounter) * foundHeight);
        } else 
        {
            timeCounter += Time.deltaTime * speed;

            xWave = (Mathf.Cos(timeCounter) * width);
            yWave = (Mathf.Sin(timeCounter) * height);

        }




        if (yWave > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }

        transform.position = transform.position + new Vector3(xWave, yWave, 0);
    }
}
