using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour {

    public GameObject Tower;

    public float downTime, upTime, pressTime = 0;
    public float countDown = 1f;
    public bool doing = false;



    // Update is called once per frame
    void Update() {
        // Build
        PlayerStatus progress = this.GetComponent<PlayerStatus>();

        if (Input.GetKeyDown("space") == true) {
            doing = true;
            downTime = Time.time;
        }

        if (Input.GetKey("space")) {
            if (downTime + countDown <= Time.time && doing == true && progress != null)
            {
                progress.DoAction(25);
                downTime = Time.time;
            }

        }
        if (Input.GetKeyUp("space") == true) {
            doing = false;
            downTime = 0;
            progress.ResetProgress();
        }

        if (progress.currentProgress >= 100 && doing == true) {
            doing = false;
            progress.currentProgress = 0;
            Vector3 spawnPosition = transform.position + (transform.forward * 2);
            Instantiate(Tower, spawnPosition, new Quaternion(0, 0, 0, 0));
        }


    }

}

