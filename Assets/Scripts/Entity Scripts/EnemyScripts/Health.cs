using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHP;
    public int currentHP;
    
	// Use this for initialization
	void Start () {
        currentHP = maxHP;
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
    }

}
