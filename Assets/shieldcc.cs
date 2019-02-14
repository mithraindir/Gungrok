using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldcc : MonoBehaviour
{

    float MoveX = 0;
    float MoveZ = 0;
    Vector3 veloSave;
    Vector3 vect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (MoveZ == 0)
            MoveX = Input.GetAxisRaw("PrimaryX");
        if (MoveX == 0)                                 //to see axis go to edit->project settings->input
            MoveZ = Input.GetAxisRaw("PrimaryZ");

        vect = new Vector3(MoveX, 0, MoveZ);
        //used to not return to edfault orientation once movement stop
        if (vect != Vector3.zero)
            veloSave = vect;

        //Make the object always face the direction it is moving in
        this.transform.rotation = Quaternion.LookRotation(vect, Vector3.up);
    }
}
