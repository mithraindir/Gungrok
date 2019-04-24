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
                
                MobSpawner.Spawn("Zombie", 235, 0, 10);
                MobSpawner.Spawn("Zombie", 245, 0, 0);
                MobSpawner.Spawn("Zombie", 235, 0, -10);
                HasSpawned = true;
            }

        }
    }
}
