using System;
using UnityEngine;

public class BackgroundController
{
    private Transform cameraTransform;
    private Transform backgroundTransform;
    private Vector3 initialOffset;

    public BackgroundController(Transform cameraTransform, Transform backgroundTransform)
    {
        this.cameraTransform = cameraTransform;
        this.backgroundTransform = backgroundTransform;
        initialOffset = backgroundTransform.position - cameraTransform.position;
    }

    public void Update()
    {
        backgroundTransform.position = cameraTransform.position + initialOffset;
    }
}
