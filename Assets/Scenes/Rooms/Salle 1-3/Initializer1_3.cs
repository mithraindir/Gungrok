using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Initializer1_3 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {

            if (collision.gameObject.tag == "ArcherPlayer")
            {
                MobSpawner.Spawn("Wizzard", 314, 0, 6);
                HasSpawned = true;
            }

        }
    }
}
