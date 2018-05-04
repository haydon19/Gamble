using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
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
                rb.AddForce(new Vector2(3, 0),ForceMode2D.Impulse);
                print("Hit from left.");
            }
            //Hit from the left or equal.
            else
            {
                print("Hit from right.");

                rb.AddForce(new Vector2(-3, 0), ForceMode2D.Impulse);
            }
        }
    }

}
