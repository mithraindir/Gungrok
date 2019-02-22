using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float angle;

    private void Start()
    {
        transform.Rotate(new Vector3(angle,0,0));
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = player.transform.position + offset;
        //remove comment /down/ to test rotation changes in real time 
       //transform.SetPositionAndRotation(player.transform.position + offset, Quaternion.Euler(angle,0,0));
    }
}
