using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Init2_8 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {

            if (collision.gameObject.tag == "ArcherPlayer" || collision.gameObject.tag == "KnightPlayer")
            {

                MobSpawner.Spawn("Ghoul", 100, 0, -285);
                MobSpawner.Spawn("Ghoul", 130, 0, -285);
                MobSpawner.Spawn("Ghoul", 120, 0, -290);
                MobSpawner.Spawn("Ghoul", 110, 0, -290);
                HasSpawned = true;
            }

        }
    }
}