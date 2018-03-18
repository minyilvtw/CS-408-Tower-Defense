using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectileStatus : MonoBehaviour {

    public int damage;

    public GameObject impactEffect;
    private LayerMask targetMask;

    private void Start()
    {
        targetMask = LayerMask.GetMask("Enemy"); 
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<EnemyStatus>() != null)
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effect, 2f);

            foreach (Collider c in Physics.OverlapSphere(transform.position, 0.5f, targetMask))
            {
                EnemyStatus enemy2 = c.GetComponent<EnemyStatus>();
                enemy2.TakeDamage(damage);
            }

        }
       
    }


}
