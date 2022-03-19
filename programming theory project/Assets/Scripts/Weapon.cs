using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask targetLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }
    private void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, 50f, targetLayer);
        if (hit)
            Destroy(hit.transform.gameObject);
    }
}
