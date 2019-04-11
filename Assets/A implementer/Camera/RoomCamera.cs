using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : MonoBehaviour
{
    public Vector3 offset;
    public float angle;
    Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
        camera.enabled = false;
        transform.Rotate(new Vector3(angle, 0, 0));
        transform.position = transform.parent.position + offset;
    }

    //test only
   /* void Update()
    {
        //remove comment /down/ to test rotation changes in real time 
        transform.SetPositionAndRotation(transform.parent.position + offset, Quaternion.Euler(angle,0,0));
    }*/
}

