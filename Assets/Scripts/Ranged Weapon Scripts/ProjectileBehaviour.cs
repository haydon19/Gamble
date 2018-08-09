using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileBehaviour : MonoBehaviour {

    // Use this for initialization
    public float speed = 10;
    public float maxTime = 10.0f;
    Rigidbody2D rb;

    public virtual void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	public virtual void Update () {


        transform.position += transform.right * Time.deltaTime * speed;

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


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {


            Destroy(transform.gameObject);
        }

        if (collision.tag == "Enemy")
        {
            //print("Enemy hit: Projectile Script");
            //Destroy(gameObject);
        }

        if (collision.tag == "PlayerAttack" && collision.gameObject.layer != 12)
        {

            transform.Rotate(new Vector3(0,0,180));
            gameObject.tag = "PlayerAttack";
            
        }
    }



}
