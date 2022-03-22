using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
