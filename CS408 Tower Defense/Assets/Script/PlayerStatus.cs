using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    public const int maxProgress = 100;
    public int currentProgress;

    public RectTransform healthBar;
    public RectTransform progressBar;

    public void Start()
    {
        currentProgress = 0;
        progressBar.sizeDelta = new Vector2(currentProgress, progressBar.sizeDelta.y);
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
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }
    }
}