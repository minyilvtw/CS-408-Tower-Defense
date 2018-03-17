using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager> {

    public GameObject root;

    public GameObject waveInfo;
    public GameObject resourceInfo;
    private Toggle sellToggle;
    private Text[] waveInfoText;
    private Text[] resourceInfoText;
    public Text[] cooldownText;

    public bool sellActive = false;

    public override void Init()
    {
        waveInfoText = waveInfo.GetComponentsInChildren<Text>();
        resourceInfoText = resourceInfo.GetComponentsInChildren<Text>();
        sellToggle = resourceInfo.GetComponentInChildren<Toggle>();

        sellToggle.onValueChanged.AddListener(delegate {
             ToggleValueChanged(sellToggle);
         });
    }

    void ToggleValueChanged(Toggle change)
    {
        sellActive = change.isOn;
        Debug.Log(sellActive);
    }

    public void DrawWaveInfo()
    {
        waveInfoText[0].text = "Level: " + LevelManager.Instance.GetLevel();
        string waveType = "";
        if (LevelManager.Instance.GetCurrentWave() % 2 == 0) {
            // Indicator, should update into Image to be easier to understand
            waveType = "Enemy";
        }
        waveInfoText[1].text = "Current Wave: " + LevelManager.Instance.GetWaveInfo() + " " + waveType;
        waveInfoText[2].text = "Time Left: " + LevelManager.Instance.GetWaveTime();
        waveInfoText[3].text = "Enemies Left: " + SpawnManager.Instance.GetEnemiesLeft();
        
    }

    public void DrawResourceInfo()
    {
        resourceInfoText[0].text = "Life: " + LevelManager.Instance.GetLifePoint();
        resourceInfoText[1].text = "Gold: " + LevelManager.Instance.GetGold();
    }

    public void DrawCooldownInfo()
    {
        // CHANGE THISS!!!!!!!!!!!!!
        cooldownText[0].text = GameObject.FindGameObjectWithTag("Player").GetComponent<AttackSpell>().GetRemainingCDText();
        cooldownText[1].text = GameObject.FindGameObjectWithTag("Player").GetComponent<AOESpell>().GetRemainingCDText();
    }

}
