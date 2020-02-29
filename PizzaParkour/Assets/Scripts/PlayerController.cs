using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;

    private InputMaster input;
    private Vector2 movement;

    private void Awake()
    {
        input = new InputMaster();
    }

    private void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // Rotate around y - axis
        movement = input.Player.Movement.ReadValue<Vector2>();
        transform.Rotate(0, movement.x * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * 1.0f;
        controller.SimpleMove(forward * curSpeed);

        Physics.gravity = new Vector3(0, -30.0F, 0);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDestroy()
    {
        input.Dispose();
    }
}
