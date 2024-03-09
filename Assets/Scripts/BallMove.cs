using UnityEngine;
using UnityEngine.UI;

public class BallMove : MonoBehaviour
{
    private float horizontal;

    [SerializeField]
    private Slider speedSlider; 

    [Range(1f, 30f)]
    [SerializeField]
    private float speed = 8f;

    private float jumpingPower = 8f;
    private bool isFacingRight = true;
    private bool isGrounded;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float movementForce = 10f;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioClip jumpClip;

    void Start()
    {
        jumpSound = GetComponent<AudioSource>();
        jumpSound.clip = jumpClip;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            if (jumpSound != null && jumpClip != null)
            {
                jumpSound.Play();
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * horizontal * movementForce);

        if (Mathf.Abs(rb.velocity.x) > speed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * speed, rb.velocity.y);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void UpdateSpeed()
    {
        speed = speedSlider.value;
    }
}
