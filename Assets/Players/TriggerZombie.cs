using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZombie : MonoBehaviourPun
{

    [Header("First Game Manager")]
    public CaCMonsterMovement ZombiePrefab;

    [HideInInspector]
    public GameObject Zombi;

    public bool ZombiSpawned = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ArcherPlayer" && !ZombiSpawned)
        {

            Debug.Log("spawn zombie");
            ZombiSpawned = true;
            CaCMonsterMovement.SpawnZombie(ref Zombi , ref ZombiePrefab);
            
        }
    }
}
