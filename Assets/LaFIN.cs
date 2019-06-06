using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class LaFIN : MonoBehaviourPun
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("KnightPlayer") || collision.gameObject == GameObject.FindGameObjectWithTag("ArcherPlayer"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
