using System.Collections;
using UnityEngine;

public class NetworkCharacter : Photon.MonoBehaviour {

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;

	void Start() {

	}

	void Update() {
		if (photonView.isMine) {
			// Do nothing -- The PlayerMotor/Movement/etc. script is moving us
		} else {
			transform.position = Vector3.Lerp (transform.position, realPosition, 0.1f);
			transform.rotation = Quaternion.Lerp (transform.rotation, realRotation, 0.1f);
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			// This is OUR player. We need to send our actual position to the network.

			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
		} else {
			// This is someone else's player. We need to receive their position (as of a few
			// millisecond ago), and update our version of that player.

			realPosition = (Vector3)stream.ReceiveNext ();
			realRotation = (Quaternion)stream.ReceiveNext ();
		}
	}

}
