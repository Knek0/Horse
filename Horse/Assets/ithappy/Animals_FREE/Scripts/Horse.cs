using System;
using UnityEngine;
public class Horse : MonoBehaviour
{
    public Transform ball;              // Reference to the rolling ball
    public PlayerController player; // Reference to the PlayerController script
    public float ballRadius = 0.75f;    // For a sphere scaled to 1.5
    public float heightOffset = 0.0f;   // Extra vertical offset above ball
    public Rigidbody rb;              // Rigidbody of the ball
    private Animator anim;

    void Awake()
    {
        anim =  GetComponent<Animator>();
    }

    void LateUpdate()
    {
        // 1. Keep the object directly above the ball
        Vector3 topPosition = ball.position + Vector3.up * (ballRadius + heightOffset);
        transform.position = topPosition;
    }

    void Update()
    {
        // 2. Rotate the object based on the input or ball's movement

        Vector3 direction = Vector3.zero;

        anim.SetFloat("Vert", 0.0f);
        anim.SetFloat("State", 0.0f);
        if (player.inputDirection.sqrMagnitude > 0.01f)
        {
            direction = player.inputDirection;
            anim.SetFloat("Vert", 1.0f);
            anim.SetFloat("State", 1.0f);
        }
        else if (rb.linearVelocity.sqrMagnitude > 0.05f)
        {
            direction = rb.linearVelocity.normalized;
            anim.SetFloat("Vert", 1.0f);
            anim.SetFloat("State", 0.0f);
        }
        else if (rb.linearVelocity.sqrMagnitude < 0.05f)
        {
            anim.SetFloat("Vert", 0.0f);
            anim.SetFloat("State", 0.0f);
        }

        // --- Only rotate on the Y-axis ---

        direction.y = 0f;
        direction.Normalize();

        // --- Smoothly Rotate Toward Direction ---

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
        }
    }
}
