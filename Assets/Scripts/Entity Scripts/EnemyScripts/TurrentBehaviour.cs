using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangedAttack))]
public class TurrentBehaviour : EnemyBehaviour {

    RangedAttack rangedAttack;

    // Use this for initialization
    public override void Start () {
        base.Start();
        rangedAttack = GetComponent<RangedAttack>();
        rangedAttack.firePoint = enemySight.transform;
    }

    private void Update()
    {
        if(enemySight.target != null)
        {
            if (enemySight.CheckLineOfSight())
            {
                //Debug.Log("Shooting at " + target.tag);
                rangedAttack.Shoot(enemySight.target);
            }

        }
    }

}
