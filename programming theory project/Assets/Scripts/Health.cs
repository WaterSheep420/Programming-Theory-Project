using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
            Die();
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
