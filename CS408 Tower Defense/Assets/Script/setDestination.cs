using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDestination : MonoBehaviour {

	//1 for front, 2 for back, 3 for right, 4 for left
	public int dir_parameter;


	private void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Enemy")
		{
			Vector3 direction;
			if (dir_parameter == 1) {
				direction = new Vector3 (0, 0, 1);//change direction to front
			} else if (dir_parameter == 2) {
				direction = new Vector3 (0, 0, -1);//change direction to back
			} else if (dir_parameter == 3) {
				direction = new Vector3 (1, 0, 0);//change direction to right
			} else if (dir_parameter == 4) {
				direction = new Vector3 (-1, 0, 0);//change direction to left
			} else {
				//wrong parameter, set 1 ~ 4 to dir_para in the ChangePoint
				Debug.Log ("Wrong parameter, exit");
				return;
			}
			//levelManager.EnemyCrossed(1);
			SpawnManager.Instance.ChangeDirection(
				col.gameObject.GetComponent<EnemyStatus>(),
				direction
			);
		}
	}
}
