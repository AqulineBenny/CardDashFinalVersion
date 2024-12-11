using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the obstacle moves
    public float minX = -5f; // Min position on the X-axis (left edge of the road)
    public float maxX = 5f;  // Max position on the X-axis (right edge of the road)

    private Vector3 targetPosition;

    void Start()
    {
        // Set initial random position along the road
        SetRandomPosition();
    }

    void Update()
    {
        // Move the obstacle towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // If the obstacle reaches its target, set a new random position
        if (transform.position == targetPosition)
        {
            SetRandomPosition();
        }
    }

    // Set a random position for the obstacle along the road
    void SetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX); // Random X position along the road
        targetPosition = new Vector3(randomX, transform.position.y, transform.position.z); // Keep Y and Z unchanged
    }
}
