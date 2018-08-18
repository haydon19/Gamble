using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerPlatformer : MonoBehaviour {
    //This class will hold and handle anything to do with the UI, keeping it seperate from the game manager
    public static UIManagerPlatformer instance;
    public Text timeText;
    [SerializeField]
    List<InventoryManager> playerMenus;

    public List<InventoryManager> PlayerMenus
    {
        get
        {
            return playerMenus;
        }

        set
        {
            playerMenus = value;
        }
    }

    // Use this for initialization
    void Start () {

        instance = this;	
	}
	
	// Update is called once per frame
	void Update () {
        if(!LevelManager.instance.end)
        timeText.text = "Time: " + Mathf.Round(LevelManager.instance.timeInLevel);
	}


}
