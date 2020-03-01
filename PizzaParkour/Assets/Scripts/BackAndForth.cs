using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
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
        float sinValue = Mathf.Sin(Time.time * movementSpeed);
        transform.position = origin + transform.forward * distance * sinValue;
    }
}
