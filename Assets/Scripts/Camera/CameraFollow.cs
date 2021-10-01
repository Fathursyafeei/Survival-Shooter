using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position; // Mendapatkan offset antara target dan camera
    }

    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset; // Mendapatkan posisi untuk kamera

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
