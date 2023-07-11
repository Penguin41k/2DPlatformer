using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _trackingObject;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = _trackingObject.transform.position.x;
        position.y= _trackingObject.transform.position.y;
        transform.position = position;
    }
}
