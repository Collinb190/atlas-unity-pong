using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    public Transform ball;
    public float paddleSpeed = 30000f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Track the ball's Y position
        Vector2 targetPosition = new Vector2(transform.position.x, ball.position.y);

        // Move towards the target position at a fixed speed
        float step = paddleSpeed * Time.deltaTime;
        rb.MovePosition(Vector2.MoveTowards(transform.position, targetPosition, step));
    }
}
