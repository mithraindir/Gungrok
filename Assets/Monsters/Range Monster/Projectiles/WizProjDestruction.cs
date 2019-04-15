using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WizProjDestruction : MonoBehaviourPun
{
    private void OnCollisionEnter(Collision collision)
    {
        if(PhotonNetwork.LocalPlayer.NickName == "Player 1")
        {
            if (!collision.gameObject.CompareTag("ennemy"))
                PhotonNetwork.Destroy(this.gameObject);
        }
        
    }
}
