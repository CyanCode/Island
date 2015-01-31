using UnityEngine;
using System.Collections;

public class NetworkCycle : Photon.MonoBehaviour {
    public Transform transform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (PhotonNetwork.player.customProperties["master"].ToString().Equals("true") && stream.isWriting) {
            stream.SendNext(transform.position);
        } else if (stream.isReading) {
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}