using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeProjectileStatus : MonoBehaviour {

    public int damage;

    public GameObject impactEffect;
    private LayerMask targetMask;

    private void Start()
    {
        targetMask = LayerMask.GetMask("Enemy");
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<EnemyStatus>() != null)
        {

            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effect, 2f);

            collider.GetComponent<EnemyStatus>().TakeDamage(damage);

        }
    }
   
}
