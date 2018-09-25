using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRotator : MonoBehaviour
{
    public float rotX;
    public float rotY;
    public float rotZ;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotX, rotY, rotZ) * Time.deltaTime);
    }
}
