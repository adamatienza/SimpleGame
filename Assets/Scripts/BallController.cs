using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float overallSpeedMultiplier = 1.2f; // Adjust this to make the ball faster (e.g., 1.5f)
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        LaunchBall();
    }

    void LaunchBall()
    {
        float xDir = (Random.value > 0.5f) ? 1f : -1f;
        float yDir = Random.Range(-0.5f, 0.5f);
        Vector2 initialVelocity = new Vector2(xDir, yDir).normalized * initialSpeed;
        rb.linearVelocity = initialVelocity;
    }

    void FixedUpdate()
    {
        // Maintain or increase the overall speed
        if (rb.linearVelocity.magnitude < initialSpeed * overallSpeedMultiplier)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * (initialSpeed * overallSpeedMultiplier);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Optional: Increase speed slightly on each hit
        // initialSpeed *= 1.05f;
    }
}