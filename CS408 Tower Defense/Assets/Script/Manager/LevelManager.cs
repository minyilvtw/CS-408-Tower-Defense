using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager> {

    private int gold = 100;
    private int currentLevel;
    private int currentWave;
    private int amountOfWaves;
    private float waveRemainingTime;

    public bool canBuild = false;

    private bool spawnActive = false;
    private bool waveActive = false;

    private List<Wave> waves = new List<Wave>();

    public override void Init()
    {
        foreach(Wave w in GetComponents<Wave>())
        {
            waves.Add(w);
        }
        currentLevel = 1;
        currentWave = 0;
        waveRemainingTime = 20;
        amountOfWaves = waves.Count;
    }

    private void Start()
    {
        // Setup UI
        UIManager.Instance.DrawWaveInfo();
        UIManager.Instance.DrawResourceInfo();
        InvokeRepeating("UpdateClock", 0f, 1f);
    }

    public void EnemyCrossed(int amount) {
    
        lifePoint = lifePoint - amount;
        UIManager.Instance.DrawResourceInfo();
        if (lifePoint <= 0) {
            Defeat();
        }
    }
	// Update is called once per frame
	void Update () {
        UIManager.Instance.DrawCooldownInfo();

        if (!waveActive && waves.Count != 0)
        {
            StartWave();
        } else {
            if(!spawnActive && !GameObject.FindGameObjectWithTag("Enemy"))
            {
                UIManager.Instance.InfoText.text = "Wave Cleared!";
                Debug.Log("Wave cleared");
                waveActive = false;
                if(waves.Count == 0)
                {
                    // when remainding wave is no longer spawning and 
                    //there are no more waves and enemies left
                    // player beats the level
                    Victory();
                }
            }
        }
	}

    private void StartWave()
    {
        if(waves.Count != 0)
        {
            waveRemainingTime = waves[0].events[0].waveDuration;
        }
        currentWave++;
        UIManager.Instance.InfoText.text = "Wave Starting!";
        Debug.Log("Wave Starting");
        waves[0].StartWave();
        spawnActive = true;
        waveActive = true;

        UIManager.Instance.DrawWaveInfo();
    }
    
    public void EndWave()
    {
        Debug.Log("Wave Ending");
        Destroy(waves[0]);
        waves.RemoveAt(0);
        waveActive = false;
        spawnActive = false;

        UIManager.Instance.DrawWaveInfo();
    }

    private void UpdateClock()
    {
        // Update timer, could find better implementation
        waveRemainingTime = waveRemainingTime - 1.0f;
        if(waveRemainingTime < 0)
        {
            waveRemainingTime = 0;
        }
        UIManager.Instance.DrawWaveInfo();
    }

    public int GetLevel()
    {
        return currentLevel;
    }

    public float GetWaveTime()
    {
        return waveRemainingTime;
    }

    public string GetWaveInfo()
    {
        return currentWave + " / " + amountOfWaves;
    }

    public int GetCurrentWave()
    {
        return currentWave;
    }

    public int GetLifePoint()
    {
        return lifePoint;
    }
    public int GetGold() {
        return gold;
    }

    public void SetGold(int amount)
    {
        gold += amount;
        UIManager.Instance.DrawResourceInfo();
    }


    private void Victory()
    {
        UIManager.Instance.InfoText.text = "Level is cleared!";
        Debug.Log("Level is cleared");

    }

    private void Defeat()
    {
        UIManager.Instance.InfoText.text = "You Lost!";
    }

}
