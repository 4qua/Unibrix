using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField]
    private Transform cameraTR;

    [SerializeField]
    private Transform playerModelRoot;

    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float playerModelRotationLerpValue = 5f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        float hor = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        var movedir = Move(new Vector3(hor, 0f, vert), transform, cameraTR);


        RotateModelTowardsDirection(movedir, playerModelRoot, playerModelRotationLerpValue); 
    }

    private Vector3 Move(Vector3 input, Transform transform, Transform cameraTransform) {

        Vector3 moveDir = cameraTransform.TransformDirection(new Vector3(input.x, 0, input.z));
        moveDir.y = 0;
        transform.position += moveDir * speed * Time.deltaTime;
        return moveDir;
    }

    private void RotateModelTowardsDirection(Vector3 direction, Transform model, float lerpVal) {
        if (direction == Vector3.zero)
            return;
        Vector3 modelForward = model.forward;
        Quaternion endRotation = Quaternion.Slerp(Quaternion.LookRotation(model.forward), Quaternion.LookRotation(direction), lerpVal * Time.deltaTime);
        model.localRotation = endRotation;
    }
}
