using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [Header("Particles")]
    [SerializeField] private ParticleSystem selfDestructParticles;
    [SerializeField] private ParticleSystem hitParticles;
    private Quaternion sdParticleRotation = Quaternion.Euler(90, 0, 0);

    [Header("Tags")]
    [SerializeField] private string targetTag;
    [SerializeField] private string ignoreTag;
    private string bulletTag = "Bullet";

    [Header("values")]
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

            if (health != null)
                health.Damage(damage);
        }
        if(!collision.CompareTag(ignoreTag) && !collision.CompareTag(bulletTag))
        {
            Instantiate(hitParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);

        Instantiate(selfDestructParticles, transform.position, sdParticleRotation);
        Destroy(gameObject);
    }
}
