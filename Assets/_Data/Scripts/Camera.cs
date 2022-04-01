using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public GameObject GameObjects;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 defalut;

    private void LateUpdate()
    {
        Vector3 desiredposition = new Vector3(0, target.position.y, target.position.z) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredposition, smoothSpeed);
        Vector3 defalutPosition = Vector3.Lerp(transform.position, defalut, 0.2f);
        if (GameObjects.activeSelf == true)
        {
            transform.position = smoothedPosition;
        }
        else
        {
            transform.position = defalutPosition;
        }
        
    }
}
