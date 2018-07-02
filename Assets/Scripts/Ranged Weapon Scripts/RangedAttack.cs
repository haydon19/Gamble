using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*TODO:
     * 1. Target only shoots if players stands still in it's line of sight.
     * 2. When this fires...it makes the thing it fires from disapear.
     * 3. The bullet doesn't instantiate.
      */


public class RangedAttack : MonoBehaviour {
    
    //Should the cooldown go in here? Or does the entity keep track of that?
    public Transform firePoint;
    public GameObject shot; //Right now this is set up to shoot any object, might be worth exploring or just let it shoot "bullets"
    public float cooldown = 1;
    public float cooldownTime = 1;
    public bool onCooldown = false;

    private void Awake()
    {
        //by default, the transform is the firepoint but we can set it later if we want
        firePoint = this.transform;
        
    }

    public void Initialize()
    {
        
    }

    void Update()
    {
        //Here we manage the cooldown / fire rate of the RangedAttack
        if (onCooldown)
        {
            cooldownTime -= Time.deltaTime;
            if(cooldownTime <= 0)
            {
                onCooldown = false;
                cooldownTime = cooldown;
            }
        }
    }

    //given a target
    public void Shoot(Transform target)
    {
        //If it's on cooldown, we can't use it so return
        if (onCooldown)
        {
            //print("On Cooldown");

            return;
        }

        onCooldown = true;
        //print("Fire!");
        //Initiates a bullet at target angle
        Vector3 vectorToTarget = target.position - firePoint.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(shot, firePoint.position, Quaternion.Euler(0, 0, angle));     


    }

    //given an angle
    public void Shoot(float angle)
    {
        //If it's on cooldown, we can't use it so return
        if (onCooldown)
        {
            //print("On Cooldown");

            return;
        }

        onCooldown = true;
        //print("Fire!");
        //Initiates a bullet at target angle

        GameObject bullet = Instantiate(shot, firePoint.position, Quaternion.Euler(0, 0, angle));


    }


}
