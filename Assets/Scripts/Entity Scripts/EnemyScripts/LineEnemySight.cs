using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEnemySight : EnemySight
{

    public override void CheckForTarget()
    {
        //10 is the "player" layer, so we bit shift it to turn it into a layer mask, which is very quick with raycasts
        int layerMask = 1 << 10;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 10, layerMask);
        Debug.DrawRay(transform.position, Vector2.left * 10, Color.green);
        if (hit)
        {
            //Debug.Log("Collided with " + hit.collider.tag);
        }

        if (hit && hit.collider.tag == "Player")
        {
            //Debug.Log("Player Sighted");
            target = hit.collider.transform;
        }
        else
        {
            target = null;
        }


    }

}

