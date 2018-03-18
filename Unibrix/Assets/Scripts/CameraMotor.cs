using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	public float xSpeed = 120.0f;
	public float ySpeed = -120.0f;

	public float yMinLimit = -20f;
	public float yMaxLimit = 85f;


	float x = 0.0f;
	float y = 0.0f;

	// Use this for initialization
	void Start() {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

	}

	void LateUpdate() {

		if (Input.GetMouseButton (1)) {

			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;

			x += Input.GetAxis ("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f;

			y = ClampAngle (y, yMinLimit, yMaxLimit);

			Quaternion rotation = Quaternion.Euler (y, x, 0);

			transform.localRotation = rotation;
		} else {
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public static float ClampAngle(float angle, float min, float max) {
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}
