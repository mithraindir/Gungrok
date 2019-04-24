using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MobHealth : MonoBehaviourPun
{
    public float HealthPoint = 5;
    public int money = 10;
    Shop_manager_archer ShopArcher;
    Shop_manager_knight ShopKnight;

    private void Start()
    {
        ShopArcher = GameObject.FindGameObjectWithTag("ShopKnight").GetComponent<Shop_manager_archer>();
        ShopKnight = GameObject.FindGameObjectWithTag("ShopKnight").GetComponent<Shop_manager_knight>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ArcherProjectile"))
            HealthPoint -= 1;

        if (HealthPoint == 0)
        {
            ShopArcher.money += money;
            ShopKnight.money += money;
            MonsterList.DeleteMonster(this.gameObject);
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
