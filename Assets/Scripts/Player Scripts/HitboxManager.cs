using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour {

    // Used for organization
    [SerializeField]
    private List<BoxCollider2D> colliders;

    // Collider on this game object
    [SerializeField]
    private BoxCollider2D activeHitbox;
    private PlayerController player;
    [SerializeField]
    private Collider2D attackTrigger;

    void Start()
    {
        player = GetComponent<PlayerController>();

        attackTrigger.gameObject.SetActive(false);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            //print("Player State: Grounded");
            player.groundState = GroundState.Grounded;


        }

        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GoalFlag")
        {
            GameManager.instance.end = true;
            GameManager.instance.ChangeScene("Scene1");
        }
    }
    /*
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
            return;

        foreach (BoxCollider2D collider in colliders)
        {
            
            collider.isTrigger = false;
            player.groundState = GroundState.Airborn;
        }
    }
    */


    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            //print("Happened");
            //print(collision.collider.tag);
            player.groundState = GroundState.Airborn;

        }
    }


    public void SetAttackTrigger(int hit)
    {
        if (hit == 0)
        {
            attackTrigger.gameObject.SetActive(false);
        }
        else
        {
            attackTrigger.gameObject.SetActive(true);
        }
    }

    public void SetHitBox(int val)
    {
        //print("activeHitbox: " + val);
        //print("colliders count: " + colliders.Count);

        activeHitbox = colliders[val];
        foreach(Collider2D collider in colliders)
        {
            if(collider != activeHitbox)
            {
                collider.gameObject.SetActive(false);
            }
            else
            {
                collider.gameObject.SetActive(true);
            }
        }
    }
}
