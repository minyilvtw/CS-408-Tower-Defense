using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOESpell : BaseSpell {

    private float hitLength;
    private Transform hitOrigin;
    private LayerMask targetMask;
    private int level;

    public AOESpell()
    {
        cooldown = 30f;
        hitLength = 5.0f;
    }

    void Start () {
        level = 1;
        lastCast = Time.time - cooldown;
        hitOrigin = this.transform;
        targetMask = LayerMask.GetMask("Enemy");
    }

    public override void Action()
    {
        GameObject.Instantiate(GameObject.Find("Explosion"), this.transform.position, this.transform.rotation);
        int damage = 30 * level;

        foreach (Collider c in Physics.OverlapSphere(hitOrigin.position, hitLength, targetMask))
        {
            EnemyStatus enemy = c.GetComponent<EnemyStatus>();
            enemy.TakeDamage(damage);
        }
    }
}
