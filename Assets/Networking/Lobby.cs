using UnityEngine;
using System.Collections;

public class Lobby : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
	}

    void OnGUI() {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby() {
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Attempting to join random room");
    }

    void OnJoinedRoom() {
        string name = PhotonNetwork.room.name;
        Debug.Log("Room: '" + name + "' successfully joined");

        SpawnPlayer player = new SpawnPlayer();
        player.CreateNewCharacter();
    }

    void OnPhotonRandomJoinFailed() {
        Debug.Log("Failed to join random room, creating one instead");

        RoomOptions options = new RoomOptions() { isVisible = true, maxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom("NewRoom", options, TypedLobby.Default);
    }

	// Update is called once per frame
	void Update () {
	    
	}
}
