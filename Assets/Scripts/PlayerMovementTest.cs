using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    public float speed = 5f; // Horizontal movement speed
    public float jumpForce = 10f; // Jump force
    public LayerMask groundLayer; // Layer to check for ground
    public Transform groundCheck; // Transform to check if the player is grounded
    public float groundCheckRadius = 0.2f; // Radius for ground checking

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Gets input for horizontal movement
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y); // Set horizontal linearVelocity
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Check if grounded

        if (Input.GetButtonDown("Jump") && isGrounded) // Listen for jump input
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply jump force
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius); // Visualize ground check
        }
    }
}
