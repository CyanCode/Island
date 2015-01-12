using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HotbarUpdate : MonoBehaviour {
    public bool updateDirection;
    public enum Direction { North, South, East, West };
    int health = 100;
    public GameObject playerPrefab;
    
	// Use this for initialization
	void Start () {
	
	}
	
    void Update() {
        if (updateDirection && PrefabIsReady()) 
            SetDirection(GetDirection());
    }

    public HotbarUpdate.Direction GetDirection() {
        if (playerPrefab != null) {
            var v = playerPrefab.transform.forward;
            v.y = 0;
            v.Normalize();
        
            if (Vector3.Angle(v, Vector3.forward) <= 45.0) {
                return Direction.North;
            } else if (Vector3.Angle(v, Vector3.right) <= 45.0) {
                return Direction.East;
            } else if (Vector3.Angle(v, Vector3.back) <= 45.0) {
                return Direction.South;
            } else {
                return Direction.West;
            }
        } else {
            return Direction.North;
        }
    }

    public void SetDirection(HotbarUpdate.Direction direction) {
        GameObject dirLabel = GameObject.Find("Direction");
        dirLabel.GetComponent<Text>().text = "Direction: " + direction.ToString();
    }

    public void SetObjective(string objective) {
        GameObject questLabel = GameObject.Find("Current Quest");
        questLabel.GetComponent<Text>().text = objective;
    }

    public void SetHealth(int health) {
        GameObject healthLabel = GameObject.Find("Health");
        healthLabel.GetComponent<Text>().text = "Health: " + health + "/100";
    }

    public void SetName(string name) {
        GameObject nameLabel = GameObject.Find("Name");
        nameLabel.GetComponent<Text>().text = name;
    }

    private bool PrefabIsReady() {
        Player player = playerPrefab.GetComponent<Player>();

        if (player != null && player.isMine) {
            return true;
        } else if (!player.isMine) {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player")) {
                Player selectedPlayer = obj.GetComponent<Player>();

                if (selectedPlayer && selectedPlayer.isMine) {
                    playerPrefab = obj;
                    return true;
                } else {
                    return false;
                }
            }

            return false;
        } else {
            return false;
        }
    }
}
