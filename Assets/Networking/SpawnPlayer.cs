using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

	public void CreateNewCharacter() {
        // Spawn player
        //Beach: x = 1411.537 y = 45.06752 z = 1609.171
        Vector3 spawn = this.transform.position;
        GameObject player = PhotonNetwork.Instantiate("characterprefab", spawn, Quaternion.identity, 0);
        PhotonNetwork.playerName = "Guest" + Random.Range(1, 9999);
        
        if (PhotonNetwork.playerList.Length > 1) {
            PhotonNetwork.player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() {{"master", "false"}});
            Debug.Log(PhotonNetwork.playerName + ": Default User");
        } else {
            PhotonNetwork.player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() {{"master", "true"}});
            Debug.Log(PhotonNetwork.playerName + ": Master User");
        }

        player.camera.enabled = true;
       
        //player.GetComponent<CharacterController>().enabled = true;
        //player.GetComponent("Main Camera").GetComponent<Camera>().enabled = true;
    }
}