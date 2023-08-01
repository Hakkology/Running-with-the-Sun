using UnityEngine;

public class CameraController
{
    private Transform playerTransform;
    private float offset;
    private Camera mainCamera;

    public CameraController(Transform playerTransform, float offset, Camera mainCamera)
    {
        this.playerTransform = playerTransform;
        this.offset = offset;
        this.mainCamera = mainCamera;
    }

    public void Update()
    {
        Vector3 newPosition = new Vector3(playerTransform.position.x + offset, mainCamera.transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = newPosition;
    }
}
