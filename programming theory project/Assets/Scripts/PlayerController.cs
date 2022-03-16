using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float horizontalInput;
    private bool canJump = true;
    private bool jumpKeyPressed;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        if (jumpKeyPressed && canJump)
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
        //canJump = false;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
