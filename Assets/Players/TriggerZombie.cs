using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZombie : MonoBehaviourPun
{

    [Header("First Game Manager")]
    public CaCMonsterMovement ZombiePrefab;
    public WizGetAction WizzardPrefab;

    [HideInInspector]
    public GameObject Zombi;
    public GameObject Wizzard;

    public bool ZombiSpawned = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ArcherPlayer"  && !ZombiSpawned)
        {
            Debug.Log("spawn zombie");
            ZombiSpawned = true;
            // CaCMonsterMovement.SpawnZombie(ref Zombi , ref ZombiePrefab, new Vector3(134.8f, 0.1f, 5.208689f));
            WizGetAction.SpawnWizzard(ref Wizzard, ref WizzardPrefab, new Vector3(134.8f, 0.1f, 5.208689f));
            
        }
    }
}
