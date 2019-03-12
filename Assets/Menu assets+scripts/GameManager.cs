using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [Header("First Game Manager")]
    public PlayerMovement PlayerPrefab;
    public PlayerMovement PlayerPrefab2;

    [HideInInspector]
    public PlayerMovement LocalPlayer;

    public bool UpDatedForPlayer2 = false;
    public int compteur = 0;

    private void Awake()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("Menu");
            return;
        }
    }

    void Start()
    {
            PlayerMovement.RefreshInstance(ref LocalPlayer, PlayerPrefab, PlayerPrefab2);
    }

    private void FixedUpdate()
    {
        if (!UpDatedForPlayer2 && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {

            compteur += 1;
            if (compteur == 100)    
            {
                UpDatedForPlayer2 = true;
                compteur = 0;
                PlayerMovement.RefreshInstance(ref LocalPlayer, PlayerPrefab, PlayerPrefab2);
                Debug.Log("actu instance");
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        PlayerMovement.RefreshInstance(ref LocalPlayer, PlayerPrefab, PlayerPrefab2);
    }

}