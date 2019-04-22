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
                
                MobSpawner.Spawn("Zombie", 283, 0, 5);
                MobSpawner.Spawn("Zombie", 283, 0, -9);
                MobSpawner.Spawn("Zombie", 270, 0, -9);
                HasSpawned = true;
            }

        }
    }
}
