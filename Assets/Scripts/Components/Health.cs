using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Death))]
public class Health : MonoBehaviour {

    public int maxHP;
    public int currentHP;
    Death deathComponent;

    [SerializeField]
    HealthBar healthBar;

	// Use this for initialization
	void Start () {
        currentHP = maxHP;
        deathComponent = GetComponent<Death>();
        healthBar.UpdateHealth(currentHP, maxHP);

    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            GainLife(-damage);
            return;
        }

        currentHP -= damage;

        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        healthBar.UpdateHealth(currentHP, maxHP);

        if(currentHP == 0)
        {
            deathComponent.OnDeath();
        }
    }

    public void GainLife(int gainz)
    {
        if (gainz < 0)
        {
            TakeDamage(-gainz);
            return;
        }

        currentHP += gainz;

        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        healthBar.UpdateHealth(currentHP, maxHP);

    }

}
