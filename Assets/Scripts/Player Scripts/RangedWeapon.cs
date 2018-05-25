using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour {

    public float fireRate = 15;
    public float damage = 10;
    public float timeToFire = 0.5f;
    public Transform firePoint;
    public GameObject shot;
    public PlayerController player;
    float angle;

    // Use this for initialization
    private void Awake()
    {
        firePoint = transform.Find("FirePoint");
    }

    void Start () {
        player = GetComponentInParent<PlayerController>();

    }

    // Update is called once per frame
    void Update () {
        //Shows sprite with pistol out
        if (player.playerState == PlayerState.RangedAttack)
        {
            //armRotation.SetActive(true);
            //input is used to read the direction of the right analog stick
            Vector3 input = new Vector3(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical"), 0.0f);
            //angle is used to determine the angle in which the right analog stick is being held
            angle = Mathf.Atan2(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical")) * Mathf.Rad2Deg - 90;
            //print("Angle: " + angle);


            //Rotate Player when aiming behind
            //print("THIS HAPPENED! Player should be facing left.");
            //Rotate the animation for the gun on the Z-axis

            if (angle <= -90)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.rotation = Quaternion.Euler(0, 0, angle - 180);


            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.rotation = Quaternion.Euler(0, 0, angle);

            }



        }

        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire"))
            {
                Shoot();
            }
        }

	}

    void Shoot()
    {

        if(Time.time > timeToFire)
        {
            timeToFire = Time.time + fireRate;
            //GameObject clone =
            
                GameObject bullet = Instantiate(shot, firePoint.position, Quaternion.Euler(0, 0, angle));


        }
        
        
    }
}

