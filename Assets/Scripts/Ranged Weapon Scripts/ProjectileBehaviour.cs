using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    // Use this for initialization
    public float speed = 1000;
    Rigidbody2D rb;
    private BoxCollider2D activeHitbox;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * 10,ForceMode2D.Impulse);

	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if(collision.collider.tag == "Enemy")
        {
            //print("Enemy hit: Projectile Script");
            Destroy(gameObject);
        }
    }

}
