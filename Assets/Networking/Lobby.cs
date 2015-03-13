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

        this.CreateNewCharacter();
    }

    void OnPhotonRandomJoinFailed() {
        Debug.Log("Failed to join random room, creating one instead");

        RoomOptions options = new RoomOptions() { isVisible = true, maxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom("NewRoom", options, TypedLobby.Default);
    }

    void OnPhotonPlayerDisconnected(PhotonPlayer player) {
        if (player.customProperties["master"].ToString().Equals("true") && PhotonNetwork.playerList.Length > 0) {
            //Transfer master ownership
            PhotonPlayer newOwner = PhotonNetwork.playerList[0];
            newOwner.SetCustomProperties(new ExitGames.Client.Photon.Hashtable(){{"master", "true"}});
        }
    }

	// Update is called once per frame
	void Update () {
	    
	}
    
    private void CreateNewCharacter() {
        Vector3 spawn = this.transform.position;
        GameObject player = PhotonNetwork.Instantiate("characterprefab", spawn, Quaternion.identity, 0);
        PhotonNetwork.playerName = "Guest" + Random.Range(1, 9999);

        player.GetComponent<Camera>().enabled = true;

       
        //player.GetComponent<CharacterController>().enabled = true;
        //player.GetComponent("Main Camera").GetComponent<Camera>().enabled = true;
    }
}
