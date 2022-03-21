using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
