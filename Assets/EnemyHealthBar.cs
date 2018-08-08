using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : HealthBar
{

    // Use this for initialization
    void Awake()
    {
        //Static reference to this object
        //Images for background and current health
        Image[] images = GetComponentsInChildren<Image>();

        foreach (Image i in images)
        {
            if (i.name == "Current Health")
            {
                health = i;
            }
        }

        text = GetComponentInChildren<Text>();
    }

    public override void UpdateHealth(float current, float max)
    {
        health.transform.localScale = new Vector3((current / max), 1, 1);
        text.text = "";
    }
}
