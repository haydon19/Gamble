using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour {

    public Transform target = null;


    // Use this for initialization
    void Start () {
		
	}


	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void CheckForTarget()
    {


    }

    public virtual bool CheckLineOfSight()
    {
        return false;
    }
}


