using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClickStartButton : MonoBehaviour
{
    public void JoinRoomSelection()
    {
        SceneManager.LoadScene("Room Selection");
    }
}
