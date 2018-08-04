using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Collectable : MonoBehaviour
{
    Collider2D collider;


    // Use this for initialization
    void Start()
    {
        collider = GetComponent<Collider2D>();
        //collider.isTrigger = true;
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            AddToInventory();
            Destroy(gameObject);
        }

    }

    public void AddToInventory()
    {
        InventoryManager.instance.AddItem(this);
    }
}
