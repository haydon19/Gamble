using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {

    public int speed = 2;
    Rigidbody2D rb;
    //this should probably keep track of the facing position

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }

    public void MoveHorizontal(int direction)
    {
        rb.velocity =  new Vector2(direction * speed, rb.velocity.y);
    }

    public void MoveVertical(int direction)
    {
        rb.velocity = new Vector2(rb.velocity.x, direction * speed);

    }
    
    public void Knockback(int direction)
    {

    }
}
