using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Transform cameraTR;

	[SerializeField]
	private Transform playerModelRoot;

	[SerializeField]
	private float speed = 5;

	[SerializeField]
	private float playerModelRotationLerpValue = 5f;

	private CharacterController controller;

	public float jumpForce = 10.0f;
	private float verticalVelocity;
	private Vector3 velocity;
	public float gravity = 5f;
	bool canJump;

	private Animator animator;

	// Use this for initialization
	void Start() {
		controller = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update() {

		float hor = Input.GetAxisRaw ("Horizontal");
		float vert = Input.GetAxisRaw ("Vertical");

		var movedir = Move (new Vector3 (hor, 0f, vert), transform, cameraTR);

		RotateModelTowardsDirection (movedir, playerModelRoot, playerModelRotationLerpValue);

		if(controller.isGrounded && !Input.GetButtonDown("Jump"))
		{
			if (verticalVelocity <= -0.4f)
			{
				verticalVelocity = -0.4f;
			}
		}

		if (!controller.isGrounded)
		{
			verticalVelocity += Physics.gravity.y * 2 * Time.deltaTime;
		}
		else
		{
			if(Input.GetButtonDown("Jump"))
			{
				Jump();
			}
		}
		velocity.y = verticalVelocity;
		controller.Move(velocity * Time.deltaTime);

	}

	private Vector3 Move(Vector3 input, Transform transform, Transform cameraTransform) {

		Vector3 moveDir = cameraTransform.TransformDirection(new Vector3(input.x, 0, input.z));

		moveDir.y = 0;
		
		controller.SimpleMove (moveDir * speed * Time.deltaTime * 100);
		return moveDir;
	}

	private void RotateModelTowardsDirection(Vector3 direction, Transform model, float lerpVal) {
		if (direction == Vector3.zero)
			return;
		direction.y = 0;
		Vector3 modelForward = model.forward;
		Quaternion endRotation = Quaternion.Slerp(Quaternion.LookRotation(model.forward), Quaternion.LookRotation(direction), lerpVal * Time.deltaTime);
		model.localRotation = endRotation;
	}

	private void Jump() {
		verticalVelocity = jumpForce;
	}

}
