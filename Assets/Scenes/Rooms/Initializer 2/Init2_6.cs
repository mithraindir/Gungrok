using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Init2_6 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {

            if (collision.gameObject.tag == "ArcherPlayer" || collision.gameObject.tag == "KnightPlayer")
            {

                MobSpawner.Spawn("Wizzard", 212, 0, -175);
                MobSpawner.Spawn("Wizzard", 212, 0, -185);
                MobSpawner.Spawn("Wizzard", 212, 0, -195);
                MobSpawner.Spawn("Ghoul", 220, 0, -180);
                MobSpawner.Spawn("Ghoul", 220, 0, -190);
                HasSpawned = true;
            }

        }
    }
}