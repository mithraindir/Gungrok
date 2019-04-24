using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Init2_4 : MonoBehaviourPun
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {

            if (collision.gameObject.tag == "ArcherPlayer" || collision.gameObject.tag == "KnightPlayer")
            {

                MobSpawner.Spawn("Ghoul", 350, 0, -100);
                MobSpawner.Spawn("Ghoul", 330, 0, -100);
                MobSpawner.Spawn("Zombie", 340, 0, -105);
                HasSpawned = true;
            }

        }
    }
}