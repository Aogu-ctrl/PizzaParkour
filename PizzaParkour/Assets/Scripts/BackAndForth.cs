using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    public enum StartDirection
    {
        FORWARD,
        BACKWARD
    };

    public enum MoveDirection
    {
        FORWARD,
        UP
    };

    public StartDirection startDirection;
    public MoveDirection moveDirection;
    public float movementSpeed;
    public float distance;
    private Vector3 origin;

    private void Awake()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float sinValue = Mathf.Sin(Time.timeSinceLevelLoad * movementSpeed);
        if (startDirection == StartDirection.BACKWARD)
        {
            sinValue *= -1;
        }

        Vector3 direction;
        if (moveDirection == MoveDirection.FORWARD)
        {
            direction = transform.forward;
        } else
        {
            direction = transform.up;
        }
        transform.position = origin + direction * distance * sinValue;
    }
}
