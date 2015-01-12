using UnityEngine;
using System.Collections;

public class Player : Photon.MonoBehaviour {
    public bool isMine = false;

	void Update() {
        if (!photonView.isMine)
            ToggleControl(false);
        else
            isMine = true;
    }

    /// <summary>
    /// Enables / disables control scripts based on player owner
    /// </summary>
    /// <param name="isEnabled"></param>
    void ToggleControl(bool isEnabled) {
        Debug.Log(PhotonNetwork.player.name + " don't own this character, disabling interaction");
        Debug.Log("Master client?: " + PhotonNetwork.player.isMasterClient);

        this.GetComponent<MouseLook>().enabled = isEnabled;
        this.GetComponent<CharacterMotor>().enabled = isEnabled;
        this.GetComponent<FPSInputController>().enabled = isEnabled;
        this.GetComponent<PhotonView>().enabled = isEnabled;
    }

    public static Player LocateMyPlayer() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player")) {
            Player play = obj.GetComponent<Player>();

            if (play.isMine) {
                return play;
            }
        }

        return null;
    }
}