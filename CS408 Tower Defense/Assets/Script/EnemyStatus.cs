using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyStatus : MonoBehaviour
{
    public float maxHealth;
    public float movementSpeed = 0.05f;
    [System.NonSerialized]
    public float currentHealth;
	public Vector3 dir;
    public RectTransform healthBar;
    public int healthBarSizeFactor;
    public bool isBoss;
    public int reward;
    public GameObject deathEffect;

    public void Start()
    {
		this.dir = new Vector3(0,0,1);
        currentHealth = maxHealth;

        healthBar.sizeDelta = new Vector2((currentHealth / maxHealth) * 100 * healthBarSizeFactor, healthBar.sizeDelta.y);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            LevelManager.Instance.SetGold(reward);
            currentHealth = 0;
            SpawnManager.Instance.DestroyEnemy(gameObject);

            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 2f);

        }
        healthBar.sizeDelta = new Vector2((currentHealth / maxHealth) * 100 * healthBarSizeFactor, healthBar.sizeDelta.y);
    }

	public void ChangeDir(Vector3 direction)
	{
		this.dir = direction;
	}

    public void Update()
	{
        CharacterController controller = GetComponent<CharacterController>();
        controller.Move(dir * movementSpeed);
    }
}