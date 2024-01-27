using UnityEngine;

public class SimplePlatformerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log(horizontalInput);
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        if(movement.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animation>().Play();   
        }
        else if (movement.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animation>().Play();
        }
        rb.velocity = movement;
    }
}
