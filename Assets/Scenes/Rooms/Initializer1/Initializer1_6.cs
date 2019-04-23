using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Initializer1_6 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {

            if (collision.gameObject.tag == "ArcherPlayer")
            {

                MobSpawner.Spawn("Wizzard", 505, 0, -8);
                MobSpawner.Spawn("Wizzard", 512, 0, 11);
                MobSpawner.Spawn("Wizzard", 505, 0, 18);
                MobSpawner.Spawn("Wizzard", 512, 0, -2);
                HasSpawned = true;
            }

        }
    }
}
