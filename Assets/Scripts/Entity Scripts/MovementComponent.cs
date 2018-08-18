using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Left = -1, Right = 1 };

public class MovementComponent : MonoBehaviour {

    Rigidbody2D m_RigidBody2D;
    [SerializeField]
    Direction direction;

    [SerializeField]
    public float speed = 5;

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
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        Direction = Direction.Left;
    }

    public void MoveTo(Vector2 destination)
    {
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);

    }

    public void MoveHorizontal()
    {
        //rb.AddForce(new Vector2(speed*2, 0));

        //rb.position += new Vector2(speed * Time.deltaTime, 0);
        Vector2 velocity = m_RigidBody2D.velocity;
        velocity.x = speed*(int)direction;
        m_RigidBody2D.velocity = velocity;
 
    }

    //Also know as jumping
    public void MoveVertical(float speed)
    {

        //rb.AddForce(new Vector2(0, speed/10));

        m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, speed);

    }

    public void AddToVertical(float speed)
    {
        m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, m_RigidBody2D.velocity.y + speed);

    }

}
