using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public int buttonNumber;

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (buttonNumber < 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().CastSpell(buttonNumber + 2);
        } else {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CreateTower>().MakeSelection(buttonNumber);
        }
    }
}
