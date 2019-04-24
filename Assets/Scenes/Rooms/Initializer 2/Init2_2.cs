using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Init2_2 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {

            if (collision.gameObject.tag == "ArcherPlayer" || collision.gameObject.tag == "KnightPlayer")
            {

                MobSpawner.Spawn("Ghoul", 240, 0, 11);
                MobSpawner.Spawn("Ghoul", 240, 0, -11);
                HasSpawned = true;
            }

        }
    }
}