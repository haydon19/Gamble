using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBoss : Enemy
{
    [SerializeField]
    float SpawnTimer;
    [SerializeField]
    float SpawnRate = 3;

    public void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_MovementComponent = GetComponent<MovementComponent>();
        m_EnemySight = GetComponentInChildren<EnemySight>();
        m_Health = GetComponent<Health>();
        SpawnTimer = 0;
    }

    public override void Reset()
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {

        if (m_EnemySight.target != null)
        {
            GetComponent<RangedAttack>().Shoot(m_EnemySight.target);
            
        }

        /*
        if(SpawnTimer > SpawnRate)
        {
            GameObject slime = Instantiate(Resources.Load("Prefabs/Enemies/Slime"), transform.position, Quaternion.identity) as GameObject;
            SpawnTimer = 0;
        } else
        {
            SpawnTimer += Time.deltaTime;
        }
        */

    }
}
