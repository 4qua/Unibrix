using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	[SerializeField]
	public float currentHealth { get; set; }
	[SerializeField]
	public float maxHealth { get; set; }

	public GameObject player;

	public Slider healthBar;

	void Start() {
		maxHealth = 100;
		currentHealth = maxHealth;

		//healthBar.value = CalculateHeath ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.X)) {
			DealDamage (6);
		}
	}

	public void DealDamage(int damageValue) {
		currentHealth -= damageValue;
		healthBar.value = CalculateHeath ();

		if (currentHealth <= 0) {
			Die ();
		}
	}

	float CalculateHeath() {
		return currentHealth / maxHealth;
	}

	// oof
	void Die() {
		currentHealth = 0; // Ensure that the player's health is 0 when dead.
		Debug.Log ("Player died. Oof.");
		//Destroy (player);
	}

}
