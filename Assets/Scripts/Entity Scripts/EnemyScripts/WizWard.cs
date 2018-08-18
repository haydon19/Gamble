using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangedAttack))]
public class WizWard : Hazard {

    RangedAttack rangedAttack;
    public EnemySight m_EnemySight;

    // Use this for initialization
    public void Start () {
        rangedAttack = GetComponent<RangedAttack>();
        rangedAttack.firePoint = m_EnemySight.transform;
    }

    private void Update()
    {
        if(m_EnemySight.target != null)
        {
            if (m_EnemySight.CheckLineOfSight())
            {
                //Debug.Log("Shooting at " + target.tag);
                rangedAttack.Shoot(m_EnemySight.target);
            }

        }
    }

}
