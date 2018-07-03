using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpComponent : MonoBehaviour {

    [Range(1, 10)]
    public float jumpVelocity;

    public float jumpAdd = 10;
    public float maxAddTime = .5f;
    public float addTime = 0;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;
    public bool jumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    public void Jump () {
        
        rb.velocity = Vector2.up * jumpVelocity;
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
