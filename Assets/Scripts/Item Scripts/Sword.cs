using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IItem, IEquippable, IWeapon
{
    [SerializeField]
    string itemName;
    [SerializeField]
    int value;
    [SerializeField]
    GameObject worldObject;
    [SerializeField]
    Vector2 damage;


    public IItem Item
    {
        get
        {
            return this;
        }
    }

    public string Name
    {
        get
        {
            return itemName;
        }

        set
        {
            itemName = value;
        }
    }

    public int Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = value;
        }
    }

    public GameObject Object
    {
        get
        {
            return worldObject;
        }

        set
        {
            worldObject = value;
        }
    }

    public Vector2 Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }


}
