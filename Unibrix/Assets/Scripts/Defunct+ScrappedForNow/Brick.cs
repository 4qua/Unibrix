using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public bool anchored = true;
	public bool canUnanchor = false;
	public float health;
	public float healthBeforeUnanchor = 0; // What the brick's health should be when it unanchors. If set to -1, then don't ever unanchor it.
	public Rigidbody rBody;

	void Start() {
		if (anchored) {
			rBody.useGravity = true;
		} else {
			rBody.useGravity = false;
		}
	}

}
