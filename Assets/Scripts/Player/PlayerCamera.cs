using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0, 0.75f, 0);
    [SerializeField] private InputReader inputReader = default;
    [SerializeField] private float horizontalSensitivity = 50f, verticalSensitivity = 50f;
    [SerializeField] private float verticalClamp = 85f;
    [SerializeField] private bool invertY = false;
    private Vector2 dir;
    private new Transform camera;
    float yRotation = 0;
    public float HorizontalSensitivity { get { return horizontalSensitivity; } set { horizontalSensitivity = value; } }
    public float VerticalSensitivity { get { return verticalSensitivity; } set { verticalSensitivity = value; } }
    private void Start()
    {
        AttachCameraToPlayer();
    }
    private void Update()
    {
        RotateHorizontal();
        RotateVertical();
    }

    private void RotateHorizontal()
    {
        transform.Rotate(Vector3.up, dir.x * horizontalSensitivity * Time.deltaTime);
    }

    private void RotateVertical()
    {
        yRotation += dir.y * verticalSensitivity * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -verticalClamp, verticalClamp);
        camera.localRotation = Quaternion.AngleAxis(yRotation, GetAxis());
    }

    private Vector3 GetAxis()
    {
        return invertY ? Vector3.right:Vector3.left;
    }

    void OnEnable()
    {
        inputReader.lookEvent += Look;
    }
    void OnDisable()
    {
        inputReader.lookEvent -= Look;
    }

    private void AttachCameraToPlayer()
    {
        Camera cam = Camera.main;
        cam.transform.parent = transform;
        ResetCameraTransform(cam);

        camera = cam.transform;
    }

    private void ResetCameraTransform(Camera cam)
    {
        cam.transform.localPosition = offset;
        cam.transform.rotation = Quaternion.identity;
    }

    void Look(Vector2 dir)
    {
        this.dir = dir;
    }
}
