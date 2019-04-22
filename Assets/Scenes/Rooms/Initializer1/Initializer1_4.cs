using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Initializer1_4 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {

            if (collision.gameObject.tag == "ArcherPlayer")
            {
                
                MobSpawner.Spawn("Wizzard", 390, 0, -80);
                MobSpawner.Spawn("Wizzard", 395, 0, -87);
                MobSpawner.Spawn("Wizzard", 390, 0, -100);
                HasSpawned = true;
            }

        }
    }
}
