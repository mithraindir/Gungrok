using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DiseableCamera : MonoBehaviourPun
{
    GameObject player;
    public new Camera camera;
    GameObject knight;
    GameObject archer;

    //verifie que la zone de trigger à été activé...
    private void OnTriggerEnter(Collider collision)
    {
        //...par le player
        if (PhotonNetwork.LocalPlayer.NickName == "Player 1")
        {
            archer = GameObject.FindGameObjectWithTag("ArcherPlayer");
            player = archer;
        }
        else
        {
            knight = GameObject.FindGameObjectWithTag("KnightPlayer");
            player = knight;
        }
        if (collision.gameObject.tag == player.tag)
        {
            camera.enabled = false;
        }
    }
}
