using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnableShop : MonoBehaviourPun
{
    GameObject player;
    GameObject shop;

    private void OnTriggerEnter(Collider collision)
    {
        //...par le player
        if (PhotonNetwork.LocalPlayer.NickName == "Player 1")
        {
            player = GameObject.FindGameObjectWithTag("ArcherPlayer");
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("KnightPlayer");
        }
        if (collision.gameObject.tag == player.tag)
        {
            shop = GameObject.FindGameObjectWithTag("ShopKnight");
            shop.GetComponent<Shop_manager_archer>().enabled = true;
            shop.GetComponent<Shop_manager_knight>().enabled = true;
        }
    }
}