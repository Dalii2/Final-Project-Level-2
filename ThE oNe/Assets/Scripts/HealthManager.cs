using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
	public int a;
	public int b;
	public float maxHealth;
	float health;
	public Behaviour[] disableOnDeath;


	void Start()
	{
		maxHealth = Random.Range(a, b);
		health = maxHealth;
		//Debug.Log(maxHealth);

	}
	public void TakeDamage(float amount)
	{
		health -= amount;
		Debug.Log(health);
		if (health <= 0)
		{
			health = 0;
			Die();
		}
		
	}
	void Die()
	{
		if (gameObject.tag == "enemy")
		{
			Destroy(gameObject);
		}
		if (gameObject.tag == "monster")
		{
			Destroy(gameObject);
		}
		//Disable all the components inside the disableOnDeath array that you will assign from the inspector
		foreach (Behaviour behaviour in disableOnDeath)
		{
			behaviour.enabled = false;
		}
	}
}
