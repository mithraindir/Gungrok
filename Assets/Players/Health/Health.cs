using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Health : MonoBehaviourPun
{
    Slider HealthSlider;
    int lifeRef;
    public int life;
    GameObject objet;
    GameObject otherPlayer;

    private void Start()
    {
        lifeRef = life;
        HealthSlider = GameObject.FindGameObjectWithTag("healthSlider").GetComponent<Slider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!photonView.IsMine)
            return;
        if (PhotonNetwork.LocalPlayer.NickName != "Player 1")
        {
            otherPlayer = GameObject.FindGameObjectWithTag("ArcherPlayer");
        }
        else
        {
            otherPlayer = GameObject.FindGameObjectWithTag("KnightPlayer");
        }
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            objet = other.gameObject;
            if (objet.tag == "ennemy" || objet.tag == "ennemyProjectile")
            {
                if (other.contacts[0].thisCollider.gameObject.tag != "shield") //check if first point of contact is shild and if not remove health
                {
                    life -= 1;
                    otherPlayer.GetComponent<Health>().life -= 1; //normalent doit retirer de la vie à l'autre joueur
                }
            }
        }
    }

    private void FixedUpdate()
    {
        HealthSlider.value = life;

        if (life <= 0)
        {
            Debug.Log("DEATH");
        }

        //cheat to regain life
        if (Input.GetKeyDown(KeyCode.Alpha1))
            life = lifeRef;
    }
}
