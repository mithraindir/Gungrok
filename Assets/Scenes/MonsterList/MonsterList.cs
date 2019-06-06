using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MonsterList : MonoBehaviourPun
{
    static List<GameObject> Monsterlist = new List<GameObject>();

    static int nb = 0;

    public static void AddMonster(GameObject Monster)
    {
        
            Monsterlist.Add(Monster);
            MonsterList.nb += 1;
        
    }

    public static void DeleteMonster(GameObject Monster)
    {
        if (Monsterlist.Contains(Monster))
        {
            Monsterlist.Remove(Monster);

        }
        nb -= 1;
    }

    public static bool IsEmpty()
    {
        return MonsterList.nb == 0;
    }

}
