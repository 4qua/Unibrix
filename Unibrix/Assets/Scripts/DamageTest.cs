using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour {

	public int damageAmount = 9999;

	public Health health;

	void Start() {
		health = GetComponent <Health> ();
	}

	void OnTriggerEnter()
	{
		health.DealDamage (damageAmount);
	}

}
