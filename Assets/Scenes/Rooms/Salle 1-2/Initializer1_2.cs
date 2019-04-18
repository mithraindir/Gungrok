using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Initializer1_2 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {

            if (collision.gameObject.tag == "ArcherPlayer")
            {
                MobSpawner.Spawn("Zombie", 224, 0, 17);
                MobSpawner.Spawn("Zombie", 237, 0, 4);
                MobSpawner.Spawn("Zombie", 224, 0, -10);
                HasSpawned = true;
            }

        }
    }
}
