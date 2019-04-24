using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Health : MonoBehaviourPun
{
    Slider HealthSlider;
    public PhotonView gameView;
    GameObject commoneHP;
    public float lifeRef;
    public float life;
    public bool upgrade;
    GameObject objet;
    GameObject otherPlayer;

    private void Start()
    {
        gameView = PhotonView.Get(this);
        lifeRef = life;
        HealthSlider = GameObject.FindGameObjectWithTag("healthSlider").GetComponent<Slider>();
        HealthSlider.maxValue = lifeRef;
        upgrade = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!photonView.IsMine)
            return;
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            objet = other.gameObject;
            if (objet.tag == "ennemy" || objet.tag == "ennemyProjectile")
            {
                if (other.contacts[0].thisCollider.gameObject.tag != "shield") //check if first point of contact is shild and if not remove health
                {
                    /*commoneHP = GameObject.FindGameObjectWithTag("CommonHP");
                    commoneHP.transform.position -= new Vector3(1, 0, 0);*/
                    gameView.RPC("HealthReduction", RpcTarget.All, null);
                }
            }
        }
    }

    [PunRPC]
    public void HealthReduction()
    {
        life--;
    }

    [PunRPC]
    public void changeHealthRef(int c)
    {
        lifeRef = c;
    }

    [PunRPC]
    public void changeHealth()
    {
        life = lifeRef;
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine) //if removed knight health sync to archer
            return;

        if (upgrade)
        {
            gameView.RPC("changeHealthRef", RpcTarget.All,lifeRef);
            gameView.RPC("changeHealth", RpcTarget.All, null);
            /*commoneHP = GameObject.FindGameObjectWithTag("CommonHP");
            commoneHP.transform.position = new Vector3(lifeRef, 0, 0);*/
            HealthSlider.maxValue = lifeRef;
            upgrade = false;
        }

        if (life <= 0)
        {
            Debug.Log("DEATH");
        }

        //cheat to regain life
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            /*commoneHP = GameObject.FindGameObjectWithTag("CommonHP");
            commoneHP.transform.position = new Vector3(3, 0, 0);*/
            gameView.RPC("changeHealth", RpcTarget.All, null);
        }

        /*commoneHP = GameObject.FindGameObjectWithTag("CommonHP");
        life = commoneHP.GetComponent<Common_Health>().Health;*/
        HealthSlider.value = life;
    }
}
