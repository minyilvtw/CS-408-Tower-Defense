using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpell : BaseSpell {

    private float hitLength;
    private Transform hitOrigin;
    private LayerMask targetMask;
    private int level;

    public AttackSpell()
    {
        cooldown = 0.75f;
        hitLength = 2.0f;
    }

    public void Start()
    {
        level = 1;
        lastCast = Time.time - cooldown;
        hitOrigin = this.transform;
        targetMask = LayerMask.GetMask("Enemy");
    }

    public override void Action()
    {
        this.GetComponentInChildren<Animation>()["Lumbering"].wrapMode = WrapMode.Once;
        this.GetComponentInChildren<Animation>().Play("Lumbering");

        int damage = 5 * level;

        foreach(Collider c in Physics.OverlapSphere(hitOrigin.position, hitLength, targetMask))
        {
            EnemyStatus enemy = c.GetComponent<EnemyStatus>();
            enemy.TakeDamage(damage);
        }
    }
}
