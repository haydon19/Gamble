using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour {

    public float damage = 10;
    public Transform firePoint;
    RangedAttack rangedAttack;
    float angle;
    [SerializeField]
    Projectile shot;

    // Use this for initialization
    private void Awake()
    {
        firePoint = transform.Find("FirePoint");
    }

    void Start () {
        rangedAttack = gameObject.AddComponent<RangedAttack>();
        rangedAttack.firePoint = firePoint;
        rangedAttack.cooldown = .5f;
        rangedAttack.shot = shot;
    }

    // Update is called once per frame
    public void UpdateAngle (Vector2 input) {
        //Shows sprite with pistol out
            //armRotation.SetActive(true);
            //input is used to read the direction of the right analog stick
            //angle is used to determine the angle in which the right analog stick is being held
            angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg - 90;
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

    public void Shoot()
    {
        rangedAttack.Shoot(angle);     
    }
}

