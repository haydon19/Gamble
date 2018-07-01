using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*TODO:
     * 1. Target only shoots if players stands still in it's line of sight.
     * 2. When this fires...it makes the thing it fires from disapear.
     * 3. The bullet doesn't instantiate.
      */


public class RangedAttack : MonoBehaviour {

    public Transform firePoint;
    public GameObject shot;

    private void Awake()
    {
        //by default, the transform is the firepoint but we can set it later if we want
        firePoint = this.transform;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void Shoot(Transform target)
    {
            print("Wizard Ward : Fire!");
        //GameObject clone =    
        //Initiates a bullet at target angle
        Vector3 vectorToTarget = target.position - firePoint.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(shot, firePoint.position, Quaternion.Euler(0, 0, angle), transform);


        

    }

         
    
        
}
