using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    public RectTransform healthBar;

    public void Start()
    {
        //currentHealth ;
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            SpawnManager.Instance.DestroyEnemy(gameObject);
        }
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    public void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        controller.Move(new Vector3(0,0,1) * .02f);
    }

}