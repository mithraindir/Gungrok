using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPun
{
    //movement speed
    public float speed = 10;

    float MoveX = 0;
    float MoveZ = 0;

    public float angle;

    public Vector3 offset;

    protected Rigidbody player;
    Vector3 veloSave;


    // Start is called before the first frame update
    void Start()
    {
        //player object
        player = GetComponent <Rigidbody>();
       // Camera.main.transform.Rotate(new Vector3(angle, 0, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (photonView.IsMine )
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

            Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " | Players In Room: " + PhotonNetwork.CurrentRoom.PlayerCount + " | RoomName: " + PhotonNetwork.CurrentRoom.Name);
            Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        }
        
    }


    public static void RefreshInstance(ref PlayerMovement player, PlayerMovement Prefab, PlayerMovement Prefab2)
    {
        var position = new Vector3(41.2f,0.29f, 6.680687f);
        var rotation = Quaternion.identity;
        if (player != null)
        {
            position = player.transform.position;
            rotation = player.transform.rotation;
            PhotonNetwork.Destroy(player.gameObject); // destroy on all clients
        }
        if (PhotonNetwork.LocalPlayer.NickName == "Player 1")
            player = PhotonNetwork.Instantiate(Prefab.gameObject.name, position, rotation).GetComponent<PlayerMovement>();
        else
            player = PhotonNetwork.Instantiate(Prefab2.gameObject.name, position, rotation).GetComponent<PlayerMovement>();

    }

}
