using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTowerStatus : TowerStatus {

    LayerMask targetMask;

    public Transform[] bulletSpawns = new Transform[8];

    private void Start()
    {
        targetMask = LayerMask.GetMask("Enemy");
        InvokeRepeating("Explode", 0f, 2 - fireRate[level]);
    }

    void Explode()
    {
        for(int i = 0; i< 8; i++)
        {
            var bullet = Instantiate(bulletPrefab[level], bulletSpawns[i].position, bulletSpawns[i].rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 15;
            Destroy(bullet, 0.35f);
        }
       

    }

}
