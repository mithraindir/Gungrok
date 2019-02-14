using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement speed
    public float speed;

    float MoveX = 0;
    float MoveZ = 0;

    private Rigidbody player;
    Vector3 veloSave;

    // Start is called before the first frame update
    void Start()
    {
        //player object
        player = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (MoveZ == 0)
            MoveX = Input.GetAxisRaw("HorizontalFR");
        if (MoveX == 0)                                 //to see axis go to edit->project settings->input
            MoveZ = Input.GetAxisRaw("VerticalFR");
        
        //make the player move
        player.velocity = new Vector3(MoveX * speed, 0, MoveZ * speed);
        //used to not return to edfault orientation once movement stop
        if (player.velocity != Vector3.zero)
            veloSave = player.velocity;

        //Make the object always face the direction it is moving in
        player.transform.rotation = Quaternion.LookRotation(veloSave, Vector3.up); 
    }
}
