using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected string deathSound;

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
        AudioManager.Instance.Play(deathSound);

        Destroy(gameObject);
    }
}
