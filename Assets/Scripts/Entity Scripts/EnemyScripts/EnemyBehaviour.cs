using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
public class EnemyBehaviour : MonoBehaviour {

    public int health = 10;
    public int dir = 1;
    public Transform target = null;
    public bool knockback = false;

    protected MovementComponent moveComponent;
    protected Rigidbody2D rb;

	// Use this for initialization
	public virtual void Start () {
        rb = GetComponent<Rigidbody2D>();
        moveComponent = GetComponent<MovementComponent>();
	}


    public virtual void CheckForTarget()
    {
        //10 is the "player" layer, so we bit shift it to turn it into a layer mask, which is very quick with raycasts
        int layerMask = 1 << 10;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left * -dir, 10, layerMask);
        Debug.DrawRay(transform.position, Vector2.left * -dir * 10, Color.green);
        if (hit)
        {
            Debug.Log("Collided with " + hit.collider.tag);
        }

        if (hit && hit.collider.tag == "Player")
        {
            Debug.Log("Player Sighted");
            target = hit.collider.transform;
        } else
        {
            target = null;
        }
        

    }

}
