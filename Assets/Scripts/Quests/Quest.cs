using UnityEngine;
using System.Collections;
using System.IO;

public class Quest : MonoBehaviour {
    public string name;
    public string id;
    public string description;
    public Items reward;
    public int amt;
    public string[] objective;
    public string[] objectiveId;
    public string completionMessage;

    private bool active;
    private string currentObjective;

	// Use this for initialization
	void Start () {
        setObjective(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetActive() {
        active = true;
    }

    public bool hasNextObjective() {
        for (int i = 0; i < objective.Length; i ++) {
            if (objective[i] == currentObjective) {
                if (objective[i + 1] != null)
                    return true;
                else
                    return false;
            }
        }

        return false;
    }

    public void nextObjective() {
        for (int i = 0; i < objective.Length; i ++) {
            if (objective[i + 1] != null && currentObjective == objective[i]) {
                currentObjective = objective[i + 1];
            } else {
                currentObjective = "No objective.";
            }
        }
    }

    public void setObjective(int index) {
        if (objective[index] != null) {
            currentObjective = objective[index];
        } else {
            currentObjective = "No objective.";
        }
    }

    public bool questFinished()
    {
        FileInfo file = new FileInfo("done.txt");
        StreamReader reader = file.OpenText();
        string text;
        
        while ((text = reader.ReadLine()) != null) {
            string lineId = text.Split(' ')[0];
            bool done = bool.Parse(text.Split(' ')[0]);

            if (lineId == id && done) {
                return true;
            }
        }

        return false;
    }

    public enum Items
    {
        Gold
    };
}
