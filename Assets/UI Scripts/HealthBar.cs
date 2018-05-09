using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public static HealthBar instance;
    public Image health;
    public Text text;

	// Use this for initialization
	void Awake () {
        //Static reference to this object
        instance = this;
        //Images for background and current health
        Image[] images = GetComponentsInChildren<Image>();
        
        foreach (Image i in images)
        {
            if(i.name == "Current Health")
            {
                health = i;
            }
        }

        text = GetComponentInChildren<Text>();
	}

    public void UpdateHealth(float current, float max)
    {
        health.transform.localScale = new Vector3((current/max), 1, 1);
        text.text = current + " / " + max;
    }

}
