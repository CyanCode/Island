using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {
    [RPC]
    void PlaySound(string name) {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = Resources.Load("Sounds/" + name) as AudioClip;
        source.Play();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            GetComponent<PhotonView>().RPC("PlaySound", PhotonTargets.All, new object[] { "help" });
        } if (Input.GetKeyDown(KeyCode.G)) {
            GetComponent<PhotonView>().RPC("PlaySound", PhotonTargets.All, new object[] { "stop" });
        } if (Input.GetKeyDown(KeyCode.Y)) {
            GetComponent<PhotonView>().RPC("PlaySound", PhotonTargets.All, new object[] { "yes" });
        } if (Input.GetKeyDown(KeyCode.N)) {
			GetComponent<PhotonView>().RPC("PlaySound", PhotonTargets.All, new object[] { "no" });
		}
    }
}
