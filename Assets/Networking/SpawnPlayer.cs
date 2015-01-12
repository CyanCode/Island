using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

	public void CreateNewCharacter() {
        // Spawn player
        //Beach: x = 1411.537 y = 45.06752 z = 1609.171
        Vector3 spawn = new Vector3(1411.537f, 45.06752f, 1609.171f);
        GameObject player = PhotonNetwork.Instantiate("characterprefab", spawn, Quaternion.identity, 0);
        PhotonNetwork.playerName = "Guest" + Random.Range(1, 9999);

        player.camera.enabled = true;

       
        //player.GetComponent<CharacterController>().enabled = true;
        //player.GetComponent("Main Camera").GetComponent<Camera>().enabled = true;
    }
}