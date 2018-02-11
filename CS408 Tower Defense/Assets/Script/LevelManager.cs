using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private int lifePoint = 10;
    private int gold = 100;

    public void EnemyCrossed() {
        lifePoint--;
        if (lifePoint == 0) {
            Defeat();
        }
    }

    private void Defeat() {
        Debug.Log("LOST");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
