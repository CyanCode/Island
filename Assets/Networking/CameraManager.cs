using UnityEngine;
using System.Collections;

public class CameraManager : Photon.MonoBehaviour {
    Camera camera;
    MouseLook mouse;
    AudioListener audio;

    void Start() {
        camera = GetComponent<Camera>();
        mouse = GetComponent<MouseLook>();
        audio = GetComponent<AudioListener>();

       if (photonView.isMine) {
           camera.enabled = true;
           mouse.enabled = true;
           audio.enabled = true;
       } else {
           camera.enabled = false;
           mouse.enabled = false;
           audio.enabled = false;
       }
	}

	// Update is called once per frame
	void Update () {
	
	}
}
