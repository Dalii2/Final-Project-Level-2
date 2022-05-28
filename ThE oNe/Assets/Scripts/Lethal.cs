using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lethal : MonoBehaviour
{
	public float damage;
	public string enemyTag;

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == enemyTag)
		{
			Debug.Log("hit");
			other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
		}
		if (other.gameObject.tag == "enemy")
		{
			Destroy(gameObject);
		}
		if (other.gameObject.tag == "rock")
		{
			Destroy(gameObject);
		}
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == enemyTag)
		{
			Debug.Log("hit");
			other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
		}
		if (other.gameObject.tag == "monster")
		{
			Destroy(gameObject);
		}
		if (other.gameObject.tag == "rock")
		{
			Destroy(gameObject);
		}
	}
}
	
