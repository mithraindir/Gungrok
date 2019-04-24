using UnityEngine;
using System.Collections;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public Button BtnConnectMaster;
    public Button BtnConnectRoom;

    public bool TriesToConnectToMaster;
    public bool TriesToConnectToRoom;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        TriesToConnectToMaster = false;
        TriesToConnectToRoom = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClickConnectToMaster()
    {
        TriesToConnectToMaster = true;
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("ca marche le master");

    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        TriesToConnectToMaster = false;
        TriesToConnectToRoom = false;
        Debug.Log(cause);
        SceneManager.LoadScene(0);
    }

    public override void OnConnectedToMaster()
    {
        TypedLobby lobby = new TypedLobby("Lobby", LobbyType.Default);
        PhotonNetwork.JoinLobby(lobby);
        Debug.Log("room disponible : " + PhotonNetwork.CountOfRooms);
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
        base.OnJoinedRoom();
        TriesToConnectToRoom = false;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        //no room available
        //create a room
        PhotonNetwork.CreateRoom("Room 1", new RoomOptions { MaxPlayers = 2 });
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log(message);
        base.OnCreateRoomFailed(returnCode, message);
        TriesToConnectToRoom = false;
    }

    public void ChoseCharacter(int nb)
    {
        if (nb == 1)
            PhotonNetwork.LocalPlayer.NickName = "Player 1";
        else
            PhotonNetwork.LocalPlayer.NickName = "Player 2";
    }

    public void LoadRoom(string RoomName)
    {
        SceneManager.LoadScene(RoomName);
    }

}