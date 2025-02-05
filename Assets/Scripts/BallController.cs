using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 350f; // Speed of the ball
    private Rigidbody rb;
    private Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity
        direction = new Vector3(1, 0, 1).normalized; // Initial diagonal movement
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction.z = -direction.z; // Reverse Z direction on wall hit
        }
        else if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("TopWall"))
        {
            direction.x = -direction.x; // Reverse X direction on paddle hit
        }

        if (collision.gameObject.CompareTag("Paddle"))
        {
            ScoreManager.instance.AddPoint();
        }

        if (collision.gameObject.CompareTag("BottomWall"))
        {
            ScoreManager.instance.GameOver();
        }

        direction = direction.normalized; // Ensure direction stays normalized
        rb.linearVelocity = direction * speed; // Maintain consistent speed
    }

    void FixedUpdate()
    {
        // Ensure the ball always moves at the correct speed
        rb.linearVelocity = direction.normalized * speed;
    }
}
