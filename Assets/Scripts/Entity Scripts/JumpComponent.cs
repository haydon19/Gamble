using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpComponent : MonoBehaviour {

    [SerializeField]
    public float jumpStrength;


    public float jumpAdd = 10;
    public float maxAddTime = .5f;
    public float addTime = 0;


    Rigidbody2D rb;
    public bool jumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    public void Jump () {

        Vector2 velocity = rb.velocity;
        rb.velocity = Vector2.up * jumpStrength;
        jumping = true;
        addTime = 0;

    }

    public void JumpAway(Direction dir)
    {
        rb.velocity = (Vector2.up * jumpStrength) + Vector2.right*jumpStrength/2*(int)dir;
        jumping = true;
        addTime = 0;
    }

    public void AddToJump()
    {
        if(jumping && addTime < maxAddTime)
        {
            addTime += Time.deltaTime;
            rb.velocity += Vector2.up * jumpAdd * Time.deltaTime;
        }
    }
    
    
    private void Update()
    {
        
        if (jumping)
        {
            

            if(rb.velocity.y <= 0)
            {
                jumping = false;
            }


        }
        
    }
    
}
