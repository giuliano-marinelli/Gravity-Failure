using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float amplitude = 0.1f;
    public float frequency = 1f;

    private Vector3 posOffset = new Vector3();
    private Vector3 tempPos = new Vector3();

    private void Start()
    {
        posOffset = transform.position;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0), Space.World);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
