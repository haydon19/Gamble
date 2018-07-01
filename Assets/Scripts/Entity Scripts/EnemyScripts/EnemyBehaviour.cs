using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
public class EnemyBehaviour : MonoBehaviour {

    public int health = 10;
    public int dir = 1;
    public PlayerController target = null;
    public bool knockback = false;

    protected MovementComponent moveComponent;
    protected Rigidbody2D rb;

	// Use this for initialization
	public virtual void Start () {
        rb = GetComponent<Rigidbody2D>();
        moveComponent = GetComponent<MovementComponent>();
	}
	
	// Update is called once per frame
	void Update () {
	}


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerAttack")
        {
            print("Hit by player!");
            //Hit from the right.
            if(collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(10, 0),ForceMode2D.Impulse);
                print("Hit from left.");
            }
            //Hit from the left or equal.
            else
            {
                //print("Hit from right.");

                rb.AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
            }
            knockback = true;
        }
    }


    public void CheckForTarget()
    {
        int layerMask = 1 << 10;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left * -dir, 10, layerMask);
        Debug.DrawRay(transform.position, Vector2.left * -dir * 10, Color.green);


        if (hit && hit.collider.tag == "Player")
        {
            Debug.Log("Player Sighted");
            target = hit.collider.transform.GetComponentInParent<PlayerController>();
        } else
        {
            target = null;
        }
        

    }

}
