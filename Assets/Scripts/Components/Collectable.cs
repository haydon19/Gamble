using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectable : MonoBehaviour
{
    [SerializeField]
    bool stackable;

    public bool Stackable
    {
        get
        {
            return stackable;
        }

        set
        {
            stackable = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        
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
        UIManagerPlatformer.instance.PlayerMenus[0].AddItem(this);
    }
}
