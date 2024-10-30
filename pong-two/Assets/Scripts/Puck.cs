using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public float startSpeed = 600f;

    private Rigidbody2D rb;
    private Vector2 startingPoint;
    private Vector2 startingLaunch;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startingPoint = rb.position;
        StartCoroutine(LaunchDelay());
    }

    private void Update()
    {
        if (rb.velocity.x > 0f && rb.velocity.x < 2.5f)
        {
            Vector2 minForcePos = new Vector2(2.5f, 0f);
            rb.AddForce(minForcePos);
        }
        else if (rb.velocity.x < 0f && rb.velocity.x > -2.5f)
        {
            Vector2 minForceNeg = new Vector2(-2.5f, 0f);
            rb.AddForce(minForceNeg);
        }
    }
  
    void Launch()
    {
        float randomDirectionY = Random.Range(-1f, 1f) >= 0 ? 1 : -1;
        float randomDirectionX = Random.Range(-1f, 1f) >= 0 ? 1 : -1;
        startingLaunch = new Vector2(randomDirectionX, randomDirectionY).normalized;
        rb.AddForce(startingLaunch * this.startSpeed);
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    public void ResetPuck()
    {
        rb.position = startingPoint;
        rb.velocity = Vector3.zero;
        StartCoroutine(LaunchDelay());
    }

    IEnumerator LaunchDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Launch();
    }
}
