using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy {

    [SerializeField]
    Vector3 wanderPoint;

    [SerializeField]
    Vector3 hoverPoint;

    [SerializeField]
    Vector2 wanderRange;

    Vector2 startPos;


    public void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_MovementComponent = GetComponent<MovementComponent>();
        m_EnemySight = GetComponentInChildren<EnemySight>();
        m_Health = GetComponent<Health>();
        wanderPoint = new Vector2(Random.Range(-wanderRange.x, wanderRange.x) + startPos.x, Random.Range(-wanderRange.y, wanderRange.y) + startPos.y);
        hoverPoint = new Vector3(-5, 5, 0);
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update () {

        

        if (m_EnemySight.target != null)
        {

            m_MovementComponent.MoveTo(m_EnemySight.target.position + hoverPoint);

            if (Vector2.Distance(m_EnemySight.target.position + hoverPoint, transform.position) < 1)
            {
                Debug.Log("H point true");
                hoverPoint = new Vector3(-hoverPoint.x, hoverPoint.y, 0);
            }
            else
            {
                Debug.Log("H point false");

            }

            if (m_EnemySight.CheckLineOfSight())
            {

                GetComponent<RangedAttack>().Shoot(m_EnemySight.target);

            }
        } else
        {

            m_MovementComponent.MoveTo(wanderPoint);

            if (Vector2.Distance(wanderPoint, transform.position) < 5)
            {
                wanderPoint = new Vector2(Random.Range(-wanderRange.x, wanderRange.x) + startPos.x, Random.Range(-wanderRange.y, wanderRange.y) + startPos.y);
            }
        }
        
        
    }

    public override void Reset()
    {
        throw new System.NotImplementedException();
    }
}
