using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyStatus : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
	public Vector3 dir;

    public RectTransform healthBar;

    public void Start()
    {
		this.dir = new Vector3(0,0,1);
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

	public void ChangeDir(Vector3 direction)
	{
		this.dir = direction;
	}

    public void Update()
	{
        CharacterController controller = GetComponent<CharacterController>();
		controller.Move(dir * .1f);
    }
}