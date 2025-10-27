using UnityEngine;

public class ObjectOnTopRotateWithBall : MonoBehaviour
{
    public Transform ball;              // Reference to the rolling ball
    public Rigidbody ballRigidbody;     // The ball's Rigidbody
    public float ballRadius = 0.75f;    // For a sphere scaled to 1.5
    public float heightOffset = 0.0f;   // Extra vertical offset above ball
    public float rotationLerpSpeed = 10f; // How quickly the object turns to match rolling direction

    private Vector3 lastForward = Vector3.forward; // Used to smooth facing direction

    void Start()
    {
        if (ballRigidbody == null)
            ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        // 1. Keep the object directly above the ball
        Vector3 topPosition = ball.position + Vector3.up * (ballRadius + heightOffset);
        transform.position = topPosition;

        // 2. Get the direction the ball is rolling (horizontal velocity only)
        Vector3 velocity = ballRigidbody.linearVelocity;
        velocity.y = 0f; // Ignore vertical component

        // 3. If the ball is moving, update facing direction
        if (velocity.sqrMagnitude > 0.001f)
        {
            Vector3 desiredForward = velocity.normalized;
            lastForward = Vector3.Lerp(lastForward, desiredForward, rotationLerpSpeed * Time.deltaTime);

            // Rotate only around Y axis to face movement direction
            Quaternion targetRotation = Quaternion.LookRotation(lastForward, Vector3.up);
            transform.rotation = targetRotation;
        }
    }
}