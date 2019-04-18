using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer1_1 : MonoBehaviour
{
    static bool HasSpawned = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (!HasSpawned)
        {

            MobSpawner.Spawn("Zombie", 124, 0, 6);
            HasSpawned = true;
        }
    }
}
