using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    // Use this for initialization
    public float speed = 1000;
    Rigidbody2D rb;
    private BoxCollider2D activeHitbox;
    public float maxTime = 10.0f;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * 10,ForceMode2D.Impulse);

	}
	
	// Update is called once per frame
	void Update () {

        //increase this gameobjects life counter
        maxTime -= Time.deltaTime;

        //destroy it if its lived too long
        if(maxTime<= 0)
        {
            Destroy(gameObject);
        }

        //TODO: check if it has left some sort of bounds

        //TODO: Check if there is too many bullets on screen, then delete the oldest one

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
