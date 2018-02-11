using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStatus : MonoBehaviour {

    public int damage;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            EnemyStatus enemy = col.GetComponent<EnemyStatus>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
