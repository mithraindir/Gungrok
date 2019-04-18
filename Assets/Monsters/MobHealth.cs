using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MobHealth : MonoBehaviourPun
{
    public float HealthPoint = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ArcherProjectile"))
            HealthPoint -= 1;

        if (HealthPoint == 0)
        {
            MonsterList.DeleteMonster(this.gameObject);
            PhotonNetwork.Destroy(this.gameObject);

        }
    }
}
