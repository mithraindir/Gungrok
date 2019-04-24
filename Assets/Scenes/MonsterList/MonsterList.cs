using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MonsterList : MonoBehaviourPun
{
    static List<GameObject> Monsterlist = new List<GameObject>();

    public static void AddMonster(GameObject Monster)
    {
        
            Monsterlist.Add(Monster);
        
    }

    public static void DeleteMonster(GameObject Monster)
    {
        if (Monsterlist.Contains(Monster))
        {
            Monsterlist.Remove(Monster);
        }
    }

    public static bool IsEmpty()
    {
        return Monsterlist.Count == 0;
    }

}
