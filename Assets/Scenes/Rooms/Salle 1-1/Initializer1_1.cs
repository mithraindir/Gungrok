using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Initializer1_1 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {
            
            if (collision.gameObject.tag == "ArcherPlayer")
            {
                MobSpawner.Spawn("Wizzard", 155, 0, 6);
                HasSpawned = true;
            }

        }
    }
}
