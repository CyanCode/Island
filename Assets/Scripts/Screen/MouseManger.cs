using UnityEngine;
using System.Collections;

public class MouseManger : MonoBehaviour {
    bool released = false;
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape) && released) {
            Screen.lockCursor = true;
            released = false;
        } else if (Input.GetKeyDown(KeyCode.Escape) && !released) {
            Screen.lockCursor = false;
            released = true;
        }
	}
}
