using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [Range(0.1f, 360.0f)]
    public float rotationSpeed = 1.0f;
    public bool invert;

    private void Update()
    {
        if (!invert)
        transform.Rotate(Vector3.up, -2 * rotationSpeed * Time.deltaTime);
        else
            transform.Rotate(Vector3.up, 2 * rotationSpeed * Time.deltaTime);
    }
}
