using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHP;
    public int currentHP;
    bool dead = false;

    [SerializeField]
    HealthBar healthBar;

	// Use this for initialization
	void Start () {
        currentHP = maxHP;

        if(healthBar != null)
        healthBar.UpdateHealth(currentHP, maxHP);

        dead = false;
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
            Die();
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

    public void Die()
    {
        GameObject coinTemp;
        for (int i = 0; i < 10; i++)
        {
            coinTemp = Instantiate(Resources.Load("Prefabs/Collectables/Coin"), transform.position, Quaternion.identity) as GameObject;
            coinTemp.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1,1), Random.Range(0,5));
            coinTemp.name = "Coin";
        }

        Destroy(gameObject);
    }

}
