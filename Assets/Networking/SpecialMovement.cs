using UnityEngine;
using System.Collections;

public class SpecialMovement : MonoBehaviour
{
    public float sprintSpeed;
    private CharacterMotor motor;
    private float startSpeed;

    // Use this for initialization
    void Start()
    {
        motor = GetComponent<CharacterMotor>();
        startSpeed = motor.movement.maxForwardSpeed;
        Debug.Log("start: " + startSpeed);
    }

    // Update is called once per frame
    void Update() {
	    if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) {
            motor.movement.maxForwardSpeed = sprintSpeed;
        } if (Input.GetKey (KeyCode.W)) {
            motor.movement.maxForwardSpeed = startSpeed;
		}
	}
}
