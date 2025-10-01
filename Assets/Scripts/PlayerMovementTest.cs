using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovementTest : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal <= 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
}
