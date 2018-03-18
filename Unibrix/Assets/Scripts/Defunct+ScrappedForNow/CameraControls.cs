using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;


    float x = 0.0f;
    float y = 0.0f;

    // Use this for initialization
    void Start() {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

    }

	void Update() {
		if (Input.GetAxis ("Mouse_ScrollWheel") > 0f) {
			GetComponent<Transform> ().position = new Vector3 (transform.position.x, transform.position.y - 6f, transform.position.z + .2f);
			transform.Rotate (-2, 0, 0);
		}

		if (Input.GetAxis ("Mouse_ScrollWheel") < 0f) {
			GetComponent<Transform> ().position = new Vector3 (transform.position.x, transform.position.y + 6f, transform.position.z - .2f);
			transform.Rotate (2, 0, 0);
		}
	}

    void LateUpdate() {
        x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

        y = ClampAngle(y, yMinLimit, yMaxLimit);

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        transform.localRotation = rotation;
    }

    public static float ClampAngle(float angle, float min, float max) {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
