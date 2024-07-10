using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public float paddleSpeed = 400f;
    public float verticalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePaddle();
    }

    void MovePaddle()
    {
        verticalInput = 0;

        if (Input.GetKey(upKey))
        {
            verticalInput = 1;
        }
        else if (Input.GetKey(downKey))
        {
            verticalInput = -1;
        }

        transform.Translate(new Vector2(0, verticalInput * paddleSpeed * Time.deltaTime));
    }
}

