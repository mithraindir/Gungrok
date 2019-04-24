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
                
                MobSpawner.Spawn("Wizzard", 328, 0, -100);
                MobSpawner.Spawn("Wizzard", 341, 0, -105);
                MobSpawner.Spawn("Wizzard", 356, 0, -100);
                HasSpawned = true;
            }

        }
    }
}
