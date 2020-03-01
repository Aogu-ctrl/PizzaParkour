using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationalSpeed;
    private float rotation = 0f;

    private void Awake()
    {
        rotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        rotation = rotation + (Time.deltaTime * rotationalSpeed) % 360f;
        transform.rotation = Quaternion.AngleAxis(rotation, transform.forward);
    }
}
