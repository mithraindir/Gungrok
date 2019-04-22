using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class spawnlife : MonoBehaviourPun
{
    public GameObject life;
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {
            if (collision.gameObject.tag == "ArcherPlayer")
            {
                PhotonNetwork.Instantiate(life.name, new Vector3(3, 0, 0), Quaternion.identity);
                HasSpawned = true;
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
