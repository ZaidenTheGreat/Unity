using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 3f;          // Speed of the platform
    public float moveDistance = 5f;   // Distance the platform moves before switching direction

    private Vector3 startPos;
    private bool movingRight = true;
    private Vector3 lastPosition;
    public Vector3 platformVelocity { get; private set; }

    void Start()
    {
        // Store the starting position of the platform
        startPos = transform.position;
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate the movement direction
        if (movingRight)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Check if the platform has moved the specified distance
        if (Vector3.Distance(startPos, transform.position) >= moveDistance)
        {
            // Reverse the direction of movement
            movingRight = !movingRight;
            // Reset the starting position
            startPos = transform.position;
        }

        // Calculate platform velocity based on movement
        platformVelocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }
}
