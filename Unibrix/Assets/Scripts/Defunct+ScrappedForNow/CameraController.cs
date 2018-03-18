using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float mouseSensitivity = 10;
	public Transform target;
	public float dstFromTarget = 2;
	public Vector2 pitchMinMax = new Vector2 (-40, 85);

	public float rotationSmoothTime = .12f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

	float yaw;
	float pitch;

	private float zoomSpeed = 2.0f;

	void LateUpdate() {

		if (Input.GetButton ("Fire2")) {
			Cursor.lockState = CursorLockMode.Locked;

			currentRotation = Vector3.SmoothDamp (currentRotation, new Vector3 (pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
			transform.eulerAngles = currentRotation;

			yaw += Input.GetAxis ("Mouse X") * mouseSensitivity;
			pitch -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
			pitch = Mathf.Clamp (pitch, pitchMinMax.x, pitchMinMax.y);
		} else {
			Cursor.lockState = CursorLockMode.None;
		}

		transform.position = target.position - transform.forward * dstFromTarget;

	}

	void Update() {
		
		float scroll = Input.GetAxis ("Mouse_ScrollWheel");
		transform.Translate (0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);

	}

}
