using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : Character {


    #region MemberVariables
    [SerializeField]
    protected EnemySight m_EnemySight;
    protected MovementComponent m_MovementComponent;
    protected RangedWeapon m_RangedWeapon;
    protected JumpComponent m_JumpComponent;
    protected GroundCheck m_GroundCheck;
    protected WallCheck m_WallCheck;
    protected DeathComponent m_DeathComponent;
    protected Rigidbody2D m_Rigidbody2D;
    protected Health m_Health;

    #endregion

    #region Fields

    public override Health Health
    {
        get
        {
            return m_Health;
        }
    }
    public override JumpComponent JumpComponent
    {
        get
        {
            return m_JumpComponent;
        }

    }

    public override DeathComponent DeathComponent
    {
        get
        {
            return m_DeathComponent;
        }

    }
    public override WallCheck WallCheck
    {
        get
        {
            return m_WallCheck;
        }

    }

    public override GroundCheck GroundCheck
    {
        get
        {
            return m_GroundCheck;
        }

    }

    public override Rigidbody2D Rigidbody2D
    {
        get
        {
            return m_Rigidbody2D;
        }

    }

    public override MovementComponent MovementComponent
    {
        get
        {
            return m_MovementComponent;
        }

    }
    #endregion

    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "PlayerAttack")
        {
            print("Hit by player!");
            Health.TakeDamage(5);

        }

    }

}
