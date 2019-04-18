using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer1_1 : MonoBehaviour
{
    static bool HasSpawned = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!HasSpawned)
        {
            
            if (collision.gameObject.tag == "ArcherPlayer")
            {
                MobSpawner.Spawn("Zombie", 124, 0, 6);
                HasSpawned = true;
            }

        }
    }
}
