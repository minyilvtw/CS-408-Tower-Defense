using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    public List<WaveEvent> events = new List<WaveEvent>();

    private bool isPlaying = false;

    public void StartWave()
    {
        isPlaying = true;
        if (events.Count != 0)
        {
            events[0].StartEvent();
        } else
        {
            LevelManager.Instance.EndWave();
        }
    }

    private void Update()
    {
        if (!isPlaying)
        {
            return;
        }

        if (!events[0].RunEvent())
        {
            Debug.Log("Event ended.");
            events.RemoveAt(0);
            if (events.Count == 0)
            {
                LevelManager.Instance.EndWave();
            }
            else
            {
                events[0].StartEvent();
            }
        }

    }

    [System.Serializable]
    public class WaveEvent
    {
        public float waveDuration = 15.0f;
        private float startTime;

        public List<SpawnInfo> spawnInfos;

        public void StartEvent()
        {
            startTime = Time.time;
        }

        public bool RunEvent()
        {
            if(waveDuration == 0.0f) //  && spawnInfos.Count == 0
            {
                return false;
            } else if (Time.time - startTime > waveDuration && waveDuration != 0.0f)
            {
                return false;
            }

            for(int i = 0; i  < spawnInfos.Count; i++)
            {
                spawnInfos[i].ReadyToSpawn();
                if(spawnInfos[i].spawnCount == 0)
                {
                    spawnInfos.RemoveAt(i);
                }
            }

            return true;
        }
    }

    [System.Serializable]
    public class SpawnInfo
    {
        public int spawnPointIndex = 0;
        public int spawnPrefabIndex = 0;
        public int spawnCount = 10;
        public float spawnInterval = 1.0f;

        private float lastSpawnedTime;

        public void ReadyToSpawn()
        {
            if(Time.time - lastSpawnedTime >= spawnInterval)
            {
                SpawnManager.Instance.Spawn(spawnPrefabIndex, spawnPointIndex);
                spawnCount--;
                lastSpawnedTime = Time.time;
            }
        }
    }

}
