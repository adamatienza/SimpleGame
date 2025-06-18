using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    public float speed = 10f;
    public string upKey = "w";
    public string downKey = "s";
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveInput = 0f;
        if (Input.GetKey(upKey))
        {
            moveInput = 1f;
        }
        else if (Input.GetKey(downKey))
        {
            moveInput = -1f;
        }

        Vector2 movement = new Vector2(0f, moveInput) * speed;
        rb.linearVelocity = movement;

        // Keep the paddle within the screen bounds (optional, but good)
        float halfHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2f;
        float topBound = Camera.main.orthographicSize - halfHeight;
        float bottomBound = -Camera.main.orthographicSize + halfHeight;
        float clampedY = Mathf.Clamp(transform.position.y, bottomBound, topBound);
        transform.position = new Vector2(transform.position.x, clampedY);
    }
}