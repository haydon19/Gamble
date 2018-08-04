using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemySight : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask;
    public Transform target;

    public void Start()
    {
        
    }

    public void CheckForTarget()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, target.position, layerMask);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //If it finds a Player Object
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

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
        //Debug.Log("Player in range");
        target = null;
    }

    //Checks whether or not a straight line of sight can be established with a raycast to whatever player enters circular hitbox.
    public bool CheckLineOfSight()
    {

        Debug.DrawLine(transform.position, target.position, Color.red);

        RaycastHit2D hit = Physics2D.Linecast(transform.position, target.position, layerMask);

        if (hit)
        {
            Debug.Log("Tag: " + hit.collider.tag);
        }

        if (hit && hit.collider.tag == "Player")
        {
            return true;
        }

        return false;


    }
}