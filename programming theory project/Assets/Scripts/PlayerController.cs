using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    private Rigidbody2D rb;

    private float horizontalInput;
    private bool jumpKeyPressed;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Vector2 groundCheckBoxSize = new Vector2(0.5f, 0.1f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        if (jumpKeyPressed && Canjump())
            Jump();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void HandleInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        jumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
    }
    void MovePlayer()
    {
        rb.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y);
    }
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private bool Canjump()
    {
        bool _canJump = Physics2D.OverlapBox(groundCheck.position, groundCheckBoxSize, 0, layerMask);
        return _canJump;
    }
    public void KnockBack()
    {
        
    }
}
