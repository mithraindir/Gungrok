using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class spriteDisable : MonoBehaviourPun
{
    public SpriteRenderer forKnight;
    public SpriteRenderer forArcher;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.LocalPlayer.NickName == "Player 1")
            forKnight.enabled = false;
        else
            forArcher.enabled = false;
    }
}
