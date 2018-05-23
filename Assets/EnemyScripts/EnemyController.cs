using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int health = 10;
    public float turnTime = 1f;
    public float timer = 0;
    public int dir = 1;
    public PlayerController target = null;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        turnTime = Random.Range(1, 5);
	}
	
	// Update is called once per frame
	void Update () {
        UpdateMovement();
        CheckForTarget();
	}


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerAttack")
        {
            print("Hit by player!");
            //Hit from the right.
            if(collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(3, 0),ForceMode2D.Impulse);
                print("Hit from left.");
            }
            //Hit from the left or equal.
            else
            {
                //print("Hit from right.");

                rb.AddForce(new Vector2(-3, 0), ForceMode2D.Impulse);
            }
        }
    }

    public void UpdateMovement()
    {
        if(timer < turnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            dir *= -1;
        }

        rb.velocity = new Vector2(2*dir,rb.velocity.y);
        //rb.AddForce(new Vector2(6 * -dir, 0));

        if(target != null && target.gameObject.transform.position.y > transform.position.y)
        {
           // rb.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
        }
    }

    public void CheckForTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left * dir, 10);
        Debug.DrawRay(transform.position, Vector2.left * dir * 10, Color.green);
  
        if (hit && hit.collider.tag == "Player")
        {
            target = hit.collider.transform.GetComponentInParent<PlayerController>();
        }
        

    }

}
