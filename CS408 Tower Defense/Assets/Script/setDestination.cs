using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDestination : MonoBehaviour {

	//1 for up, 2 for down, 3 for left, 4 for right
	public int direction;

	// Update is called once per frame
	private void OnTriggerEnter(Collider col) {
		Debug.Log ("Collide");
		Debug.Log ("In collider");
		if (direction == 1) {
			EnemyStatus.dir = new Vector3 (0, 0, 1);
		} else if (direction == 2) {
			EnemyStatus.dir = new Vector3 (0, 0, -1);
		} else if (direction == 3) {
			EnemyStatus.dir = new Vector3 (-1, 0, 0);
		} else {
			EnemyStatus.dir = new Vector3 (1, 0, 0);
		}
	}
}
