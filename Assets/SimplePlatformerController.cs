using UnityEngine;

public class SimplePlatformerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    public float jumpForce = 10000f;
    public LayerMask groundLayer;
    private bool _isGrounded;
    [SerializeField]
    private Transform groundCheck;
    private float groundCheckRadius = 0.1f;

    [SerializeField]
    private GameObject _graphicHolder;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 6)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == 6)
        {
            _isGrounded = false;
        }
    }

    private void Update()
    {
        //_isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        if(movement.x > 0)
        {
            _graphicHolder.GetComponent<SpriteRenderer>().flipX = false;
            _graphicHolder.GetComponent<Animation>().Play();   
        }
        else if (movement.x < 0)
        {
            _graphicHolder.GetComponent<SpriteRenderer>().flipX = true;
            _graphicHolder.GetComponent<Animation>().Play();
        }
        rb.velocity = movement;


        


    }
}
