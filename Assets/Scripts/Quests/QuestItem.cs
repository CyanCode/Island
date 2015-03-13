using UnityEngine;
using System.Collections;

public class QuestItem : MonoBehaviour {
    public string itemId;
    public bool isReward;
    public bool selectable;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && CanPickup())
            PickupObject();
	}

    public void PickupObject() {

    }

    public bool CanPickup() {
        Transform selfPos = this.gameObject.transform;
        Transform characterPos = Player.LocateMyPlayer().gameObject.transform;
        float distance = Vector3.Distance(selfPos.position, characterPos.position);
        
        Camera playerCam = Player.LocateMyPlayer().gameObject.GetComponent<Camera>();
        RaycastHit hit;
        var cameraLoc = playerCam.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, GetComponent<Camera>().nearClipPlane));

        bool fairDistance = (distance > 5) ? true : false;
        bool onObject = (Physics.Raycast(cameraLoc, this.transform.forward, out hit, 1000)) ? true : false;

        if (fairDistance && onObject) {
            return true;
        } else {
            return false;
        }
    }
}
