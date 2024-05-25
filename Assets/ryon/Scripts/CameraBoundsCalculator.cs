using UnityEngine;

public class CameraBoundsCalculator : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    public Bounds GetCameraBounds()
    {
        float camHeight = 2f * mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        Vector3 camPos = mainCamera.transform.position;

        Bounds bounds = new Bounds();
        bounds.min = new Vector3(camPos.x - camWidth / 2, camPos.y - camHeight / 2, 0);
        bounds.max = new Vector3(camPos.x + camWidth / 2, camPos.y + camHeight / 2, 0);

        return bounds;
    }
}
