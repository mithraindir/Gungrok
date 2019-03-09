using UnityEngine;
using System.Collections;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkConnectionManager : MonoBehaviourPunCallbacks
{

    public Button BtnConnectMaster;
    public Button BtnConnectRoom;

    public bool TriesToConnectToMaster;
    public bool TriesToConnectToRoom;

    // Use this for initialization
    void Start()
    {
        TriesToConnectToMaster = false;
        TriesToConnectToRoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        BtnConnectMaster.gameObject.SetActive(!PhotonNetwork.IsConnected && !TriesToConnectToMaster);
        BtnConnectRoom.gameObject.SetActive(PhotonNetwork.IsConnected && !TriesToConnectToMaster && !TriesToConnectToRoom);
    }

    public void OnClickConnectToMaster()
    {
        //PhotonNetwork.NickName = "PlayerName";       //to set a player name
        PhotonNetwork.AutomaticallySyncScene = true; //to call PhotonNetwork.LoadLevel()

        TriesToConnectToMaster = true;
        PhotonNetwork.ConnectUsingSettings();
        
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        TriesToConnectToMaster = false;
        TriesToConnectToRoom = false;
        Debug.Log(cause);
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        TriesToConnectToMaster = false;
        Debug.Log("Connected to Master!");
    }

    public void OnClickConnectToRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        TriesToConnectToRoom = true;
        //PhotonNetwork.CreateRoom("Peter's Game 1"); //Create a specific Room - Error: OnCreateRoomFailed
        PhotonNetwork.JoinRoom("Room 1");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " | Players In Room: " + PhotonNetwork.CurrentRoom.PlayerCount + " | RoomName: " + PhotonNetwork.CurrentRoom.Name);
        base.OnJoinedRoom();
        TriesToConnectToRoom = false;
        Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " | Players In Room: " + PhotonNetwork.CurrentRoom.PlayerCount + " | RoomName: " + PhotonNetwork.CurrentRoom.Name);
        SceneManager.LoadScene("Niveau test");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        //no room available
        //create a room (null as a name means "does not matter")
        PhotonNetwork.CreateRoom("Room 1", new RoomOptions { MaxPlayers = 2 });
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log(message);
        base.OnCreateRoomFailed(returnCode, message);
        TriesToConnectToRoom = false;
    }

}