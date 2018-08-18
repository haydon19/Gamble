using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{

    string Name { get; set; }
    int Value { get; set; }
    GameObject Object { get; set; }

    //bool AddToInventory();


}

public interface IEquippable
{
    IItem Item { get; }


}

public interface IWeapon
{
    Vector2 Damage { get; }

}

public interface IConsumable
{
    IItem Item { get; }
    void Consume();
}

