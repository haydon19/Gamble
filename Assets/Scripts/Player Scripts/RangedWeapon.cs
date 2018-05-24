using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour {

    public float fireRate = 15;
    public float damage = 10;
    public float timeToFire = 0.5f;
    public Transform firePoint;
    public GameObject shot;

    // Use this for initialization
    private void Awake()
    {
        firePoint = transform.Find("FirePoint");
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(fireRate == 0)
        {
            if (Input.GetButtonDown("Fire"))
            {
                Shoot();
            }
        }
	}

    void Shoot()
    {
        var angle = Mathf.Atan2(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical")) * Mathf.Rad2Deg - 90;

        Vector3 firePointPosition = new Vector3(0, 0, angle);

        if(Time.time > timeToFire)
        {
            timeToFire = Time.time + fireRate;
            //GameObject clone =
            GameObject bullet = Instantiate(shot, firePoint.position, firePoint.rotation);
        }
        
        
    }
}

