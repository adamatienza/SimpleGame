using UnityEngine;

public class AIPaddleController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Transform ball;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindBall(); // Call the FindBall method at the start
    }

    void FixedUpdate()
    {
        Debug.Log($"AI Paddle - Ball Transform: {ball}"); // DEBUG: Check if the ball is being found

        if (ball != null)
        {
            float targetY = ball.position.y;
            float currentY = transform.position.y;
            float moveDirection = Mathf.Sign(targetY - currentY);
            Vector2 movement = new Vector2(0f, moveDirection) * speed;
            rb.linearVelocity = movement;
            Debug.Log($"AI Paddle Velocity: {rb.linearVelocity}"); // DEBUG: Check the calculated velocity

            // Keep the paddle within the screen bounds (optional)
            float halfHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2f;
            float topBound = Camera.main.orthographicSize - halfHeight;
            float bottomBound = -Camera.main.orthographicSize + halfHeight;
            float clampedY = Mathf.Clamp(transform.position.y, bottomBound, topBound);
            transform.position = new Vector2(transform.position.x, clampedY);
            Debug.Log($"AI Paddle Position: {transform.position}"); // DEBUG: Check the final position
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // Stop if no ball is found
            FindBall(); // Try to find the ball again in case it respawned
        }
    }

    // Separate method to find the ball by tag
    void FindBall()
    {
        GameObject ballObject = GameObject.FindGameObjectWithTag("Ball");
        if (ballObject != null)
        {
            ball = ballObject.transform;
            Debug.Log("AI Paddle: Ball found!"); // DEBUG: Confirmation of finding the ball
        }
        else
        {
            Debug.LogError("AI Paddle: Ball not found! Make sure the Ball GameObject is tagged 'Ball'.");
        }
    }
}