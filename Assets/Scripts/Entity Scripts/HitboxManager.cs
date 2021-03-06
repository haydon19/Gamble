﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour {

    // Used for organization
    [SerializeField]
    private List<Collider2D> colliders;

    // Collider on this game object
    [SerializeField]
    private Collider2D activeHitbox;
    private Player player;
    [SerializeField]
    private Collider2D attackTrigger;

    void Start()
    {
        player = GetComponent<Player>();

        attackTrigger.gameObject.SetActive(false);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GoalFlag")
        {
            //LevelManager.instance.end = true;
        }
        if(collision.tag == "SpikeTrap")
        {
            print("Dead!");
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
