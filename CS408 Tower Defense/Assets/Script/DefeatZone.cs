using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatZone : MonoBehaviour {
    public LevelManager levelManager;

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            levelManager.EnemyCrossed();
            Destroy(col.gameObject);
        }
    }
}
