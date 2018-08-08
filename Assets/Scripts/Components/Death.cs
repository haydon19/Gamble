using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    bool dead = false;
	// Use this for initialization
	void Start () {
        dead = false;
    }
	
    public void OnDeath()
    {
        Destroy(gameObject);
    }

}
