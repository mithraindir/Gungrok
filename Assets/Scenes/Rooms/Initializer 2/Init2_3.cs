using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Init2_3 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {

            if (collision.gameObject.tag == "ArcherPlayer" || collision.gameObject.tag == "KnightPlayer")
            {

                MobSpawner.Spawn("Wizzard", 355, 0, -10);
                MobSpawner.Spawn("Wizzard", 355, 0, 10);
                MobSpawner.Spawn("Ghoul", 350, 0, 0);
                HasSpawned = true;
            }

        }
    }
}