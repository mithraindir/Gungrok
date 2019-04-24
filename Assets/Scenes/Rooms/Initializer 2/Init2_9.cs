using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Init2_9 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {

            if (collision.gameObject.tag == "ArcherPlayer" || collision.gameObject.tag == "KnightPlayer")
            {

                MobSpawner.Spawn("Ghoul", 238, 0, -290);
                MobSpawner.Spawn("Ghoul", 238, 0, -280);
                MobSpawner.Spawn("Ghoul", 238, 0, -270);
                MobSpawner.Spawn("Zombie", 245, 0, -285);
                MobSpawner.Spawn("Zombie", 245, 0, -275);
                MobSpawner.Spawn("Zombie", 245, 0, -265);
                HasSpawned = true;
            }

        }
    }
}