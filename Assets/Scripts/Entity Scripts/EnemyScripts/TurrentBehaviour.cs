using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangedAttack))]
public class TurrentBehaviour : EnemyBehaviour {


    public Transform sightOrigin;
    RangedAttack rangedAttack;

    // Use this for initialization
    public override void Start () {
        base.Start();
        rangedAttack = GetComponent<RangedAttack>();
        rangedAttack.firePoint = sightOrigin;
    }

    private void Update()
    {
        if(target != null)
        {
            if (CheckLineOfSight(target))
            {
                Debug.Log("Shooting at " + target.tag);
                rangedAttack.Shoot(target);
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //If it finds a Player Object
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        Debug.Log("Player in range");

        //Acquire Player (Transform)Position
        target = collision.transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If it finds a Player Object
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        Debug.Log("Player in range");
        target = null;
    }



    //Checks whether or not a straight line of sight can be established with a raycast to whatever player enters circular hitbox.
    bool CheckLineOfSight(Transform target)
    {
        int layerMask = 1 << 0;
        layerMask = ~layerMask;
        Debug.DrawLine(sightOrigin.position, target.position, Color.red);

        RaycastHit2D hit = Physics2D.Linecast(sightOrigin.position, target.position, layerMask);
        if (hit)
        {
            Debug.Log("Collided with " + hit.collider.tag);
        }

        if (hit && hit.collider.tag == "Player")
        {
            return true;
        }

        return false;
        

    }

}
