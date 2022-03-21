using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector2 moveDir = new Vector2(player.transform.position.x - transform.position.x, 0);
        rb.velocity = new Vector2(moveDir.normalized.x * speed * Time.deltaTime, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneLoader.Instance.ReloadScene();
        }
    }
}
