﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    //This class will hold and handle anything to do with the UI, keeping it seperate from the game manager
    public static UIManager instance;
    public Text timeText;
	// Use this for initialization
	void Start () {
        instance = this;	
	}
	
	// Update is called once per frame
	void Update () {
        if(!GameManager.instance.end)
        timeText.text = "Time: " + Mathf.Round(Time.time);
	}
}
