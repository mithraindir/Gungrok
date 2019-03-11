using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviourPun
{
    public Transform player;
    public Vector3 offset;
    public float angle;
    GameObject knight;
    GameObject archer;

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.LocalPlayer.NickName == "Player 1")
        {
            archer = GameObject.FindGameObjectWithTag("ArcherPlayer");
            player = archer.transform;
        }
        else
        {
            knight = GameObject.FindGameObjectWithTag("KnightPlayer");
            player = knight.transform;
        }
        transform.position = player.transform.position + offset;
        //remove comment /down/ to test rotation changes in real time 
        transform.SetPositionAndRotation(player.transform.position + offset, Quaternion.Euler(angle, 0, 0));
    }
}
