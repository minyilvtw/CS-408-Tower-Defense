using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStatus : MonoBehaviour {

    public int damage;
    public float speed;

    [System.NonSerialized]
    public Transform target;

    public GameObject impactEffect;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public virtual void HitTarget() {
        Destroy(gameObject);
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);

        EnemyStatus enemy = target.GetComponent<EnemyStatus>();
        enemy.TakeDamage(damage);

    }

}
