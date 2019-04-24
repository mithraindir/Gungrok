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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ArcherProjectile"))
            HealthPoint -= 1;

        if (HealthPoint == 0)
        {
            photonView.RPC("Money", RpcTarget.All, null);
            /*ShopArcher = GameObject.FindGameObjectWithTag("ShopKnight").GetComponent<Shop_manager_archer>();
            ShopKnight = GameObject.FindGameObjectWithTag("ShopKnight").GetComponent<Shop_manager_knight>();
            ShopArcher.money += money;
            ShopKnight.money += money;*/
            photonView.RPC("DeleteMonster", RpcTarget.All, null);
            
            PhotonNetwork.Destroy(this.gameObject);
        }
    }

    [PunRPC]
    public void Money()
    {
        ShopArcher = GameObject.FindGameObjectWithTag("ShopKnight").GetComponent<Shop_manager_archer>();
        ShopKnight = GameObject.FindGameObjectWithTag("ShopKnight").GetComponent<Shop_manager_knight>();
        ShopArcher.money += money;
        ShopKnight.money += money;
    }

    [PunRPC]
    public void DeleteMonster()
    {
        MonsterList.DeleteMonster(this.gameObject);
        MonsterList.DeleteMonster(null);
    }

}
