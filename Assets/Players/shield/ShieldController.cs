using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldController : MonoBehaviour
{

    float MoveX = 0;
    float MoveZ = 0;
    Vector3 vect;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("PrimaryX") != 0 || Input.GetAxisRaw("PrimaryZ") != 0)
        {
            if (MoveZ == 0)
                MoveX = Input.GetAxisRaw("PrimaryX");
            if (MoveX == 0)                        
                MoveZ = Input.GetAxisRaw("PrimaryZ");
            vect = new Vector3(MoveX, 0, MoveZ);
            transform.rotation = Quaternion.LookRotation(vect, Vector3.up);
            transform.position = transform.parent.position;
            transform.position += transform.forward;
        }
        else
        {
            transform.rotation = transform.parent.rotation;
            transform.position = transform.parent.position;
            transform.position += transform.forward;
        }
    }
}
