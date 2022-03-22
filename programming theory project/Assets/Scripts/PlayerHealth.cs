using UnityEngine;

public class PlayerHealth : Health //Inheritence time
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerController controller;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
    public override void Die()
    {
        SceneLoader.Instance.ReloadScene();
    }
}
