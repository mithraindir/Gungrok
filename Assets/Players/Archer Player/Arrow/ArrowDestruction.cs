using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ArrowDestruction : MonoBehaviourPun
{
    GameObject projectile;

    private void OnCollisionEnter(Collision collision)
    {
           if (PhotonNetwork.LocalPlayer.NickName == "Player 1")
        {
            if (!collision.gameObject.CompareTag("ArcherPlayer") && !collision.gameObject.CompareTag("KnightPlayer"))
                PhotonNetwork.Destroy(this.gameObject);
        }
            
    }
}
