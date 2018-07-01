using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangedAttack))]
public class TurrentBehaviour : MonoBehaviour {

    public float fireRate = 1;
    public float fireTime = 0;
    public RangedAttack rangedAttack;
    public Transform sightOrigin;
    public Transform target;
    public bool isDetected;

    // Use this for initialization
    void Start () {
        rangedAttack = GetComponent<RangedAttack>();
	}
	
	// Update is called once per frame
	void Update () {
        fireTime += Time.deltaTime;
        //Shoot
        if (fireTime >= fireRate)
        {
            if (isDetected)
            {
                rangedAttack.Shoot(target);

            }

            fireTime = 0;
        }
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
        if (isDetected == true)
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
