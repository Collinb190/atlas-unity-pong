using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Paddle
{
    private Vector2 direction;

    void Update()
    {
        PaddleDirection();
    }

    void FixedUpdate()
    {
        PaddleMovement();
    }

    void PaddleDirection()
    {
        if (Input.GetKey(KeyCode.W)) { direction = Vector2.up; }
        else if (Input.GetKey(KeyCode.S)) { direction = Vector2.down; }
        else { direction = Vector2.zero; }
    }

    void PaddleMovement()
    {
        if (direction.sqrMagnitude != 0)
        {
            rb.AddForce(direction * this.paddleSpeed);
        }
    }
}
