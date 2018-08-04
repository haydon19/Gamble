using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public static InventoryManager instance;
    List<InventoryIconScript> collectables;
    [SerializeField]
    GameObject inventory;
    bool tucked;


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
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (tucked)
            {
                transform.position = new Vector3(0, 0);
                tucked = !tucked;
            }else{
                transform.position = new Vector3(0, -160);
                tucked = !tucked;

            }

        }
    }

    // Use this for initialization
    void Start () {
        if (instance != null)
            Destroy(this);

        instance = this;
        tucked = true;

        collectables = new List<InventoryIconScript>();
        

    }
	
    public void AddItem(Collectable collectable)
    {
        InventoryIconScript temp = Instantiate(Resources.Load("Prefabs/UI/InventoryIcon", typeof(InventoryIconScript)) as InventoryIconScript, inventory.transform);
        temp.Initialize();
        Debug.Log(temp.itemIcon);
        temp.itemIcon.sprite = collectable.GetComponent<SpriteRenderer>().sprite;
    }


}
