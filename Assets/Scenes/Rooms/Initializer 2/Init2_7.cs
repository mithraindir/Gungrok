using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Init2_7 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {

            if (collision.gameObject.tag == "ArcherPlayer" || collision.gameObject.tag == "KnightPlayer")
            {

                MobSpawner.Spawn("Zombie", 107, 0, -180);
                MobSpawner.Spawn("Zombie", 107, 0, -190);
                MobSpawner.Spawn("Ghoul", 107, 0, -185);
                MobSpawner.Spawn("Wizzard", 100, 0, -175);
                MobSpawner.Spawn("Wizzard", 100, 0, -185);
                MobSpawner.Spawn("Wizzard", 100, 0, -195);
                HasSpawned = true;
            }

        }
    }
}