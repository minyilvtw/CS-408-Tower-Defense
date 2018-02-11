using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAreaCheck : MonoBehaviour {

    public GameObject detector;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == detector)
            LevelManager.Instance.canBuild = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == detector)
            LevelManager.Instance.canBuild = false;
    }
}
