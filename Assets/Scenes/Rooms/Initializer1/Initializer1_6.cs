using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Initializer1_6 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {

            if (collision.gameObject.tag == "ArcherPlayer")
            {

                MobSpawner.Spawn("Wizzard", 450, 0, 10);
                MobSpawner.Spawn("Wizzard", 460, 0, 10);
                MobSpawner.Spawn("Wizzard", 470, 0, 5);
                MobSpawner.Spawn("Wizzard", 440, 0, 5);
                HasSpawned = true;
            }

        }
    }
}
