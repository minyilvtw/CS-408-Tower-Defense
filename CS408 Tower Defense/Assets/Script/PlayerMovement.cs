using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : UnitMovement {

    protected override void UpdateMovement()
    {
        //Get input
        MoveVector = InputDirection();
        //Send input to check condition, State: walk, jump, air etc

        //Move
        Move();

    }

    private Vector3 InputDirection() {
        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        if (dir.magnitude > 1) {
            dir.Normalize();
        }

        return dir;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
