using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
public class EnemyBehaviour : MonoBehaviour {

    public int health = 10;
    public int dir = 1;
    public bool knockback = false;
    public EnemySight enemySight;
    
    protected Rigidbody2D rb;

	// Use this for initialization
	public virtual void Start () {
        rb = GetComponent<Rigidbody2D>();
        enemySight = GetComponentInChildren<EnemySight>();
	}


    

}
