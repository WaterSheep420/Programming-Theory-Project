using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectile;

    [SerializeField] private float range;
    [SerializeField] private float fireRate;
    bool targetInRange = false;
    private float timer = 0;

    void Update()
    {
        //abstraction
        HandleTimer();
        FindTarget();
    }
    protected virtual void HandleTimer()
    {
        timer += Time.deltaTime;
        if (timer > 1 / fireRate)
        {
            timer = 0;
            Fire();
        }
    }
    void FindTarget()
    {
        Vector2 direction = (player.position - transform.position);
        if (direction.magnitude > range)
        {
            targetInRange = false;
            return; 
        }

        targetInRange = true;
        transform.right = direction.normalized;
    }
    void Fire()
    {
        if(targetInRange)
            Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
