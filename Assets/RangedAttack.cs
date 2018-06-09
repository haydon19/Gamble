using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {

    public float fireRate = 15;
    public float damage = 10;
    public float timeToFire = 0.5f;
    public Transform firePoint;
    public GameObject shot;
    public Transform target;
    public bool isDetected;
    public bool shotPossible;

    private void Awake()
    {
        firePoint = this.transform;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (fireRate == 0 && shotPossible == true)
        {
            Shoot(target);
        }
    }

    void Shoot(Transform target)
    {
        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + fireRate;
            //GameObject clone =
            transform.LookAt(target);
            GameObject bullet = Instantiate(shot, firePoint.position, target.rotation);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        isDetected = true;
        CheckSight(collision.gameObject);
        target = collision.transform;
        if (shotPossible == true)
        {
            Shoot(target);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        isDetected = true;
        CheckSight(collision.gameObject);
        target = collision.transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        target = null;
        isDetected = false;
        shotPossible = false;
    }

    void CheckSight(GameObject target)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,(target.transform.position - transform.position), out hit))
        {
            if(hit.collider.gameObject.name == "Player")
            {
                shotPossible = true;
                print("WizardWard can see player!");
            }
            else
            {
                shotPossible = false;
                print("WizardWard is idle.");
            }
        }
    }

}
