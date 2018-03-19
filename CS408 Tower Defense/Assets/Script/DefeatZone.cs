using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatZone : MonoBehaviour {

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            if (col.GetComponent<EnemyStatus>().isBoss)
            {
                LevelManager.Instance.EnemyCrossed(5);
            } else
            {
                LevelManager.Instance.EnemyCrossed(1);
            }
            SpawnManager.Instance.DestroyEnemy(col.gameObject);
        }
    }
}
