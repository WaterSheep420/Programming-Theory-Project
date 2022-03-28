using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private string ignoreTag;

    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private int damage;
    private void Awake()
    {
        StartCoroutine(SelfDestruct());
    }
    private void Update()
    {
        transform.Translate(Vector3.right * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            Health health = collision.GetComponent<Health>();
            health.Damage(damage);
        }
        if(!collision.CompareTag(ignoreTag))
            Destroy(gameObject);
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
