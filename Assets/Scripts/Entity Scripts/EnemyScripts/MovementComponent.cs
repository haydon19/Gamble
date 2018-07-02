using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {

    Rigidbody2D rb;
    //this should probably keep track of the facing position

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    public void Move(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    public void MoveHorizontal(float speed)
    {
        rb.velocity =  new Vector2(speed, rb.velocity.y);
    }

    //Also know as jumping
    public void MoveVertical(float speed)
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);

    }

    public void AddToVertical(float speed)
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + speed);

    }

}
