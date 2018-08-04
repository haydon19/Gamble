using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementComponent : MonoBehaviour {

    Rigidbody2D rb;
    Direction direction;

    public Direction Direction
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
        }
    }

    //this should probably keep track of the facing position

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Direction = Direction.Left;
    }

    public void Move(Vector2 velocity)
    {
        rb.velocity = velocity;

        
    }

    public void MoveHorizontal(float speed)
    {
        //rb.AddForce(new Vector2(speed*2, 0));

        //rb.position += new Vector2(speed * Time.deltaTime, 0);

        rb.velocity = new Vector2(speed, rb.velocity.y);
 
    }

    //Also know as jumping
    public void MoveVertical(float speed)
    {

        //rb.AddForce(new Vector2(0, speed/10));

        rb.velocity = new Vector2(rb.velocity.x, speed);

    }

    public void AddToVertical(float speed)
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + speed);

    }

}
