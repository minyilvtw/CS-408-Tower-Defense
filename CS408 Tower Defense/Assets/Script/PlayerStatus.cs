using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour
{

    public int maxWood = 100;
    private int currentWood;

    public const int maxProgress = 100;
    public int currentProgress;

    public RectTransform healthBar;
    public RectTransform progressBar;

    private List<BaseSpell> spellBook = new List<BaseSpell>();

    public void Start()
    {
        currentProgress = 0;
        progressBar.sizeDelta = new Vector2(currentProgress, progressBar.sizeDelta.y);
        currentWood = maxWood;
        AddSpell();
    }

    private void AddSpell()
    {
        spellBook.Add(gameObject.AddComponent<AttackSpell>() as BaseSpell);
        spellBook.Add(gameObject.AddComponent<ThrowSpell>() as BaseSpell);
        spellBook.Add(gameObject.AddComponent<AOESpell>() as BaseSpell);

    }

    public void CastSpell(int x)
    {
        spellBook[x].Cast();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spellBook[0].Cast();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            spellBook[1].Cast();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            spellBook[2].Cast();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.GetComponent<CreateTower>().MakeSelection(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.GetComponent<CreateTower>().MakeSelection(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.GetComponent<CreateTower>().MakeSelection(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            this.GetComponent<CreateTower>().MakeSelection(3);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            LevelManager.Instance.SetGold(100);
        }

    }


    public void DoAction(int amount) {
        currentProgress += amount;
        if (currentProgress <= 100) {
            progressBar.sizeDelta = new Vector2(currentProgress, progressBar.sizeDelta.y);
        }
    }

    public void ResetProgress()
    {
        currentProgress = 0;
        progressBar.sizeDelta = new Vector2(currentProgress, progressBar.sizeDelta.y);
    }

    public void TakeDamage(int amount)
    {
        currentWood -= amount;
        if (currentWood <= 0)
        {
            currentWood = 0;
            Debug.Log("Dead!");
        }
    }
}