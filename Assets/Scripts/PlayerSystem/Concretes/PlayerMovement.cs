using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalMoveSpeed { get; private set; } = 5;
    public float verticalMoveSpeed { get; private set; } = 10;

    private float xRange = 3.8f;

    public void Move(float horizontalInput)
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * verticalMoveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * horizontalMoveSpeed * Time.deltaTime);
    }

    public void RangeControll()
    {
        if (transform.position.x <= -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
