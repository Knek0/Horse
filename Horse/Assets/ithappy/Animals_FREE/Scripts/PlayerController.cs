using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Bullet Object
    public GameObject bulletPrefab;

    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // Speed at which the player moves.
    public float speed = 0;

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnShoot(InputValue movementValue)
    {
        // Placeholder for shooting functionality.
        Debug.Log("Pew Pew");
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward * 1.10f + transform.up * 1.05f, transform.rotation);
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);

        // Fix: Check if movement is zero using Vector3's equality operator
        if (movement != Vector3.zero)
        {
            float angle = Mathf.Atan2(movementX, movementY) * Mathf.Rad2Deg;
            Vector3 rotation = new(0, angle, 0); //Rotate around the y-axis
            transform.eulerAngles = rotation;
        }
    }
}