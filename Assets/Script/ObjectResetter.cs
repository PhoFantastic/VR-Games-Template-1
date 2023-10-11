using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectResetter : MonoBehaviour
{
    [SerializeField] private Transform[] objectsToReset;
    private Vector3[] initialPositions;
    private Quaternion[] initialRotations;
    [Header("Keyboard Input")]
    public KeyCode resetKey = KeyCode.R;

    private void Start()
    {
        SaveInitialTransforms();
    }

    private void Update()
    {
        // Check for keyboard input to trigger the reset
        if (Input.GetKeyDown(resetKey))
        {
            ResetObjects();
        }
    }

    // Function to save the initial positions and rotations of objects
    private void SaveInitialTransforms()
    {
        initialPositions = new Vector3[objectsToReset.Length];
        initialRotations = new Quaternion[objectsToReset.Length];

        for (int i = 0; i < objectsToReset.Length; i++)
        {
            initialPositions[i] = objectsToReset[i].position;
            initialRotations[i] = objectsToReset[i].rotation;
        }
    }

    // Function to reset objects to their initial positions and rotations
    public void ResetObjects()
    {
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].position = initialPositions[i];
            objectsToReset[i].rotation = initialRotations[i];
        }
    }

    // Optionally, you can add an Editor function to refresh the array in the Inspector
#if UNITY_EDITOR
    [ContextMenu("Refresh Object Array")]
    private void RefreshObjectArray()
    {
        objectsToReset = GetComponentsInChildren<Transform>();
    }
#endif
}
