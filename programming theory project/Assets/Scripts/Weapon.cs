using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int weaponDamage;

    [SerializeField] private Transform firePoint;
    [SerializeField] private LineRenderer laserSight;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private string enemyTag;

    RaycastHit2D hit;
    Vector3 raycastEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(firePoint.position, firePoint.right, 50f, ~playerLayer);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }
    private void Shoot()
    {
        if (!hit)
            return;
        if (hit.transform.CompareTag(enemyTag))
            hit.transform.gameObject.GetComponent<Health>().TakeDamage(weaponDamage);
    }
    private void LateUpdate()
    {
        if (hit)
            raycastEnd = hit.point;
        else
            raycastEnd = firePoint.position + firePoint.right * 50;

        laserSight.SetPosition(0, firePoint.position);
        laserSight.SetPosition(1, raycastEnd);
    }
}
