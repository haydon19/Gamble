using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPad : MonoBehaviour {

    [SerializeField]
    WarpPad destination;

    bool justWarped;
    Vector2 offset;
	// Use this for initialization
	void Start () {
        justWarped = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Warp(Transform warpee)
    {
        destination.justWarped = true;
        warpee.position = destination.transform.position;
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log(collider.name);
            if (justWarped)
            {
                justWarped = false;
            }
            else
            {
                Warp(collider.transform.root);
            }
        }

    }


}
