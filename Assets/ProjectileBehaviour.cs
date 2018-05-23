using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    // Use this for initialization
    public float speed = 500;
    Rigidbody2D rb;
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed);
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
    }

}
