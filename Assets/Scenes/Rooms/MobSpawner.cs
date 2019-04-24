using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MobSpawner : MonoBehaviourPun
{
    public GameObject Zombie;
    static GameObject SZombie;
    public CaCMonsterMovement ZombiePrefab;
    static CaCMonsterMovement SZombiePrefab;

    public GameObject Ghoul;
    static GameObject SGhoul;
    public CaCMonsterMovement GhoulPrefab;
    static CaCMonsterMovement SGhoulPrefab;

    public GameObject Wizzard;
    static GameObject SWizzard;
    public WizGetAction WizzardPrefab;
    static WizGetAction SWizzardPrefab;

    private void Start()
    {
        SZombie = Zombie;
        SZombiePrefab = ZombiePrefab;

        SWizzard = Wizzard;
        SWizzardPrefab = WizzardPrefab;

        SGhoul = Ghoul;
        SGhoulPrefab = GhoulPrefab;
    }

    public static GameObject Spawn(string mob, float x, float y, float z)
    {
        
        if (mob == "Wizzard")
        {
            GameObject wizzard = WizGetAction.SpawnWizzard(ref SWizzard, ref SWizzardPrefab, new Vector3(x, y, z));
            MonsterList.AddMonster(wizzard);
            return wizzard;
        }

        if (mob == "Zombie")
        {
            GameObject zombie = CaCMonsterMovement.SpawnZombie(ref SZombie, ref SZombiePrefab, new Vector3(x, y, z));
            MonsterList.AddMonster(zombie);
            return zombie;
        }

        if (mob == "Ghoul")
        {
            GameObject ghoul = CaCMonsterMovement.SpawnGhoul(ref SGhoul, ref SGhoulPrefab, new Vector3(x, y, z));
            MonsterList.AddMonster(ghoul);
            return ghoul;

        }

        return null;
    }
   
}
