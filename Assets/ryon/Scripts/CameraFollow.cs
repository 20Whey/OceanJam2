using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;           // Reference to the player
    public Vector3 offset;             // Offset from the player
    public float smoothSpeed = 0.125f; // Speed of the smooth follow
    public float maxDistance = 5f;     // Maximum distance from the player

    private Vector3 currentVelocity;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Ensure the camera's z position is fixed at -10
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }

    void FixedUpdate()
    {
        // Calculate the midpoint between the player and the mouse position
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        Vector3 midpoint = (player.position + mouseWorldPosition) / 2;

        // Add the offset
        midpoint += offset;

        // Clamp the position to the maximum distance
        Vector3 clampedPosition = ClampPosition(midpoint);

        // Smoothly move the camera towards the clamped position
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, clampedPosition, ref currentVelocity, smoothSpeed);
        transform.position = smoothedPosition;
    }

    Vector3 GetMouseWorldPosition()
    {
        // Get the mouse position in world space for 2D game
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Mathf.Abs(Camera.main.transform.position.z); // Use the distance from the camera to the player

        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    Vector3 ClampPosition(Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - player.position;
        if (directionToTarget.magnitude > maxDistance)
        {
            targetPosition = player.position + directionToTarget.normalized * maxDistance;
        }

        return new Vector3(targetPosition.x, targetPosition.y, -10f);
    }
}
