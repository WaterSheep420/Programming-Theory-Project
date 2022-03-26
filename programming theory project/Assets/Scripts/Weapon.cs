using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int weaponDamage;
    [SerializeField] private float range;

    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask ignoreRaycast;
    [SerializeField] private string enemyTag;

    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(firePoint.position, firePoint.right, range, ~ignoreRaycast);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }
    private void Shoot()
    {
        if (!hit)
            return;
        if (hit.transform.CompareTag(enemyTag))
            Debug.Log("enemy hit");
    }
}
