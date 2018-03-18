using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmStatus : TowerStatus {

    void Start()
    {
        InvokeRepeating("MakeGold", 0f, 1f);
    }

    void MakeGold()
    {
        LevelManager.Instance.SetGold((level + 1) * 2);
    }

}
