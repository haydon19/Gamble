using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*TODO:
     * 1. Target only shoots if players stands still in it's line of sight.
     * 2. When this fires...it makes the thing it fires from disapear.
     * 3. The bullet doesn't instantiate.
      */


public class RangedAttack : MonoBehaviour {

    public float fireRate = 5;
    public float fireTime = 0;
    public float damage = 10;
    public float timeToFire = 0.5f;
    public Transform firePoint;
    public GameObject shot;
    public Transform target;
    public Transform sightOrigin;
    public bool isDetected;

    private void Awake()
    {
        firePoint = this.transform;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        fireTime += Time.deltaTime;
        //Shoot
        if(fireTime >= fireRate)
        {
            if (isDetected)
            {
                Shoot(target);

            }

            fireTime = 0;
        }
    }

    void Shoot(Transform target)
    {
            print("Wizard Ward : Fire!");
        //GameObject clone =    
        //Initiates a bullet at target angle
        Vector3 vectorToTarget = target.position - firePoint.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(shot, firePoint.position, Quaternion.Euler(0, 0, angle), transform);


        

    }

         
    private void OnTriggerStay2D(Collider2D collision)
    {
        //If it finds a Player Object
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        //Acquire Player (Transform)Position
        target = collision.transform;
        CheckSight(target);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If cannot find a Player : Do nothing.
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        //Flushes target data.
        target = null;
        isDetected = false;
    }

    //Checks whether or not a straight line of sight can be established with a raycast to whatever player enters circular hitbox.
    void CheckSight(Transform target)
    {
        isDetected = Physics2D.Linecast(sightOrigin.position, target.position);
        if(isDetected == true)
        {
            Raycasting();
        }
    }
    void Raycasting()
    {
        if (target != null)
        {
            Debug.DrawLine(sightOrigin.position, target.position, Color.red);
        }
    }
        
}
