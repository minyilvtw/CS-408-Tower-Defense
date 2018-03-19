using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatus : MonoBehaviour {

    [Header("Attributes")]
    public int level = 0;
    public static int maxLevel = 2;
    public List<int> cost = new List<int>(maxLevel);
    public List<int> sell = new List<int>(maxLevel);
    public List<float> range = new List<float>(maxLevel);
    public List<float> fireRate = new List<float>(maxLevel);
    public List<string> Description = new List<string>(maxLevel);
    public List<GameObject> bulletPrefab = new List<GameObject>(maxLevel);

    [Header("Unity Setup Fields")]
    public Transform bulletSpawn;
    public Transform partToRotate;

    public float rotationSpeed = 8f;

    [System.NonSerialized]
    public Transform target;

    private float fireCountdown = 0f;

    public void Upgrade()
    {
        level = level + 1;
    }

	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 1f);
	}

    void UpdateTarget() {

        if (this.GetComponent<BladeTowerStatus>() != null)
        {
            Debug.Log("BLADE");
            return;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int lowestHealth = 99999999;
        float shortestDistance = Mathf.Infinity;
        GameObject bestEnemy = null;

        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            float enemyHealth = enemy.GetComponent<EnemyStatus>().currentHealth;
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                bestEnemy = enemy;
            }
 
        }
        
        if (bestEnemy != null && shortestDistance <= range[level])
        {
            target = bestEnemy.transform;
        }
    }

    void Update () { 
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime).eulerAngles;
        //transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if(partToRotate != null) { 
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, rotationSpeed * Time.deltaTime).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        if (fireCountdown <= 0f)
        {
            Fire();
            fireCountdown = 1f / fireRate[level];
        }

        fireCountdown -= Time.deltaTime;

    }


    void Fire()
    {
        if (this.GetComponent<BladeTowerStatus>() != null)
        {
            Debug.Log("BLADE");
            return;
        }

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

    private void OnMouseOver()
    {
        
    }

    void OnMouseDown()
    {

        float shortestDistance = Mathf.Infinity;
        GameObject bestSpot = null;

        if (UIManager.Instance.sellActive)
        {
            foreach(GameObject towerZone in GameObject.FindGameObjectsWithTag("TowerSpawnZone"))
            {
                float distanceToZone = Vector3.Distance(gameObject.transform.position, towerZone.transform.position);
                
                if (distanceToZone < shortestDistance)
                {
                    shortestDistance = distanceToZone;
                    bestSpot = towerZone;
                }
            }

            bestSpot.GetComponent<ZoneBuildable>().zoneTaken = false;
            Debug.Log("SOLD!");
            Destroy(gameObject);
            LevelManager.Instance.SetGold(sell[level]);
        } else {
            float distanceToPlayer = Vector3.Distance(gameObject.transform.position, GameObject.Find("Player").transform.position);
            if (level < 2 && LevelManager.Instance.GetGold() > cost[0] && distanceToPlayer < 5.0f)
            {
                Upgrade();
                Debug.Log("Upgrade!");
                LevelManager.Instance.SetGold(-cost[0]);
                
            }
            
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range[level]);
    }

}
