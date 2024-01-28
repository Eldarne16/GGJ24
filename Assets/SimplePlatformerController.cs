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

    [SerializeField]
    private GameObject _graphicHolder;
    [SerializeField]
    private GameObject _underwaterBreathing;
    [SerializeField]
    private FollowObject _followObject;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Infos.instance.GetHandler<SceneHandler>().NextLevel(true);
        }
        if(collision.gameObject.layer == 4)
        {
            _underwaterBreathing.SetActive(true);
            _followObject.StartChangeOffset();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 6)
        {
            _isGrounded = true;
        }
        if(collision.collider.gameObject.layer == 7)
        {
            Infos.instance.GetHandler<SceneHandler>().NextLevel(false);
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
