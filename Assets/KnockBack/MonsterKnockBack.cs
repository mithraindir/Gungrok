using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKnockBack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ca marche");
    }
}
