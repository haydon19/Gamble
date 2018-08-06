using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryIconScript : MonoBehaviour {

     
    public Image itemIcon;

    public Text stackSize;
    public int numItems;

    // Use this for initialization
    public void Initialize(int n)
    {
        itemIcon = GetComponent<Image>();
        stackSize = GetComponentInChildren<Text>();
        numItems = n;
        stackSize.text = "" + numItems;
    }

    public void Initialize()
    {
        itemIcon = GetComponent<Image>();
        stackSize = GetComponentInChildren<Text>();
        stackSize.text = "";
    }

    public void AddToStack(int n)
    {

        numItems += n;
        stackSize.text = "" + numItems;

    }
}
