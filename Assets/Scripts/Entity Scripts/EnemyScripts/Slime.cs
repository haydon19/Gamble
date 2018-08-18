using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
public class Slime : Enemy {

    public float turnTime = 1f;
    public float timer = 0;

    // Use this for initialization
    public void Start () {

        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_MovementComponent = GetComponent<MovementComponent>();
        m_EnemySight = GetComponentInChildren<EnemySight>();
        m_Health = GetComponent<Health>();
        turnTime = Random.Range(1, 5);
        m_GroundCheck = GetComponent<GroundCheck>();
        m_WallCheck = GetComponent<WallCheck>();
    }


    private void FixedUpdate()
    {

        if (m_EnemySight.target != null)
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


        if (m_MovementComponent.Direction < 0)
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
            m_MovementComponent.Direction = (Direction)((int)m_MovementComponent.Direction * -1);

        }

        if (m_GroundCheck.groundState == GroundState.Grounded && !m_WallCheck.IsWall)
            m_MovementComponent.MoveHorizontal();
    }

    void HasTargetBehaviour()
    {

        if (m_EnemySight.target.position.x < transform.position.x)
        {
            m_MovementComponent.Direction = Direction.Left;
        }
        else
        {
            m_MovementComponent.Direction = Direction.Right;
        }
        //Shoot
        if (m_EnemySight.CheckLineOfSight())
        {
            GetComponent<RangedAttack>().Shoot(m_EnemySight.target);

        } else
        {
            MoveToTarget();
        }

        
    }

    void MoveToTarget()
    {
        

        m_MovementComponent.MoveHorizontal();
    }

    public override void Reset()
    {
        throw new System.NotImplementedException();
    }

    //There was problems with this in the genereal enemy code, due to the fact that the Turret was an enemy but didnt have a rigidbody
    //To fix this, we should either give enemies a collision manager, and then different types can managed their own types of collisions
    //or we seperate the enemies into collidable and non-collidable


}
