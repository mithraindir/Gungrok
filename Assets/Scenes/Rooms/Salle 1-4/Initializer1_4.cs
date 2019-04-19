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
                MobSpawner.Spawn("Wizzard", 385, 0, 17);
                MobSpawner.Spawn("Wizzard", 397, 0, 4);
                MobSpawner.Spawn("Wizzard", 385, 0, -10);
                HasSpawned = true;
            }

        }
    }
}
