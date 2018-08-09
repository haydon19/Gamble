using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : MonoBehaviour {

    public Health health;
    public EnemySight enemySight;
    protected Rigidbody2D rb;
    protected MovementComponent moveComponent;

    // Use this for initialization
    public virtual void Start () {

        rb = GetComponent<Rigidbody2D>();
        enemySight = GetComponentInChildren<EnemySight>();
        health = GetComponent<Health>();

	}


    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "PlayerAttack")
        {
            print("Hit by player!");
            health.TakeDamage(5);

        }

    }

}
