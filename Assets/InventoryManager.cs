using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    Dictionary<string, InventoryIconScript> collectables;
    [SerializeField]
    GameObject inventory;
    bool tucked;
    Vector2 startingPos;


    private void OnMouseOver()
    {
        transform.position = new Vector3(0, 0);
        print(gameObject.name);
    }

    private void OnMouseExit()
    {
        transform.position = new Vector3(0, -160);

    }

    private void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            if (tucked)
            {
                transform.localPosition = startingPos + new Vector2(0, 175);
                tucked = !tucked;
            }else{
                transform.localPosition = startingPos;
                tucked = !tucked;

            }

        }
    }

    // Use this for initialization
    void Start () {

        tucked = true;
        startingPos = transform.localPosition;
        collectables = new Dictionary<string, InventoryIconScript>();
        

    }

    public void AddItem(Collectable collectable)
    {
        if (collectables.ContainsKey(collectable.name) && collectable.Stackable)
        {
            collectables[collectable.name].AddToStack(1);
        }
        else
        {

            InventoryIconScript temp = Instantiate(Resources.Load("Prefabs/UI/ItemStackIcon", typeof(InventoryIconScript)) as InventoryIconScript, inventory.transform);
            if (collectable.Stackable)
            {
                temp.Initialize(1);
            }
            else
            {
                temp.Initialize();
            }
            temp.itemIcon.sprite = collectable.GetComponent<SpriteRenderer>().sprite;
            collectables.Add(collectable.name, temp);
        }
    }


}
