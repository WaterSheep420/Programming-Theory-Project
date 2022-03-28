using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireRate;
    [SerializeField] private int weaponDamage;

    private float timer;

    void Update()
    {
        if(Input.GetButton("Fire1"))
            Shoot();
    }
    private void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= 1 / fireRate)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            timer = 0;
        }
    }
}
