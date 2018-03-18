using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour {

	public Renderer rend;

	void Start() {
		rend = GetComponent<Renderer> ();
	}

	public void ChangeRed() {
		rend.material.SetColor ("_Color", Color.red);
	}

	public void ChangeGreen() {
		rend.material.SetColor ("_Color", Color.green);
	}

	public void ChangeBlue() {
		rend.material.SetColor ("_Color", Color.blue);
	}

}
