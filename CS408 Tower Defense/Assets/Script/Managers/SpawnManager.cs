using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager> {

    public List<Transform> spawnPoint = new List<Transform>();
    public List<GameObject> spawnPrefabs = new List<GameObject>();

	private List<GameObject> activeEnemies = new List<GameObject>();

    public void Spawn(int spawnPrefabIndex)
    {
        Spawn(spawnPrefabIndex, 0);
    }

    public void Spawn(int spawnPrefabIndex, int spawnPointIndex) {
        GameObject go = Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation);
        activeEnemies.Add(go);
    }

    public void DestroyEnemy(GameObject go)
    {
        activeEnemies.Remove(go);
        Destroy(go);
    }

	public void ChangeDirection( EnemyStatus go, Vector3 direction ) {
		go = (EnemyStatus)go;
		go.ChangeDir (direction);
	}

    public int GetEnemiesLeft()
    {
        return activeEnemies.Count;
    }

    public void Update()
    {
     
    }
}