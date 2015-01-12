using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {
    CharacterController input;
    private Vector3 correctPlayerPos;
    private Quaternion correctPlayerRot;

    void Awake() {
        input = GetComponent<CharacterController>();

        if (photonView.isMine) {
            input.enabled = true;
        } else {
            input.enabled = false;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            // We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            Debug.Log("Sending position: " + transform.position);
        } else {
            // Network player, receive data
            this.correctPlayerPos = (Vector3)stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
            Debug.Log("Receiving position: " + transform.position);
        }
    }

    void Update() {
        if (!photonView.isMine) {
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
        }
    }
}