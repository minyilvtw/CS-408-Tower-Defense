using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatus : MonoBehaviour {

    public GUIContent Icon;
    public int level = 0;
    public List<int> cost;
    public List<int> sell;
    public List<float> range;
    public List<string> Description;
    public List<GameObject> bulletPrefab;
    public Transform bulletSpawn;

    public Transform partToRotate;
    public float rotationSpeed = 8f;

    public Transform target;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 1f);
	}

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int lowestHealth = 99999999;
        GameObject bestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            
            int enemyHealth = enemy.GetComponent<EnemyStatus>().currentHealth;
            if (enemyHealth < lowestHealth)
            {
                lowestHealth = enemyHealth;
                bestEnemy = enemy;
            }
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (bestEnemy != null && distanceToEnemy < range[level])
            {
                target = bestEnemy.transform;
                Fire();
            } else
            {
                target = null;
            }
        }
    }

    void Update () { 
        if(target == null)
        {
            return;
        }

        //transform.LookAt(target.position);
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        //Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, rotationSpeed * Time.deltaTime).eulerAngles;
        //partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


    }



    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = Instantiate(
            bulletPrefab[level],
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
       // bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 13;
        ProjectileStatus projStat = bullet.GetComponent<ProjectileStatus>();

        if(projStat != null)
        {
            projStat.Seek(target);
        }

        Destroy(bullet, 3.0f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range[level]);
    }

}
