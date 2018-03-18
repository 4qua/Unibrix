using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

	public GameObject loadingCam;
	SpawnSpot[] spawnSpots;

	void Start() {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot> ();
		Connect ();
	}

	void Connect() {
		PhotonNetwork.ConnectUsingSettings ("Unibrix Pre-Alpha Build_1");
	}

	void OnGUI() {
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

	void OnJoinedLobby() {
		Debug.Log ("Joined lobby");
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed() {
		Debug.Log ("Photon random join failed.");
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom() {
		Debug.Log ("Joined room");

		SpawnMyPlayer ();
	}

	void SpawnMyPlayer() {
		if (spawnSpots == null) {
			Debug.LogError ("YO MY DUDE THERE'S NO SPAWNS WHAT THE FUCK AAAAAA");
		}
		SpawnSpot mySpawnSpot = spawnSpots[ Random.Range(0, spawnSpots.Length) ];
		GameObject myPlayerGO = (GameObject)PhotonNetwork.Instantiate ("Player", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
		loadingCam.SetActive (false);
		myPlayerGO.GetComponent<PlayerMotor> ().enabled = true;
		myPlayerGO.transform.Find ("CameraRoot").gameObject.SetActive (true);
	}

}
