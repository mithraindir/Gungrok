using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class WizGetAction : MonoBehaviourPun
{
    public float ReloadTime = 200;
    float compteurRT = 0;

    Rigidbody PrefabWizzard;

    public float DureeDeplacement = 200;
    public float ReloadDeplacement = 800;
    float compteurDD = 0;
    float compteurRD = 0;

    public float VitesseDeplacement = 60;
    

    public GameObject projectile;
    [Header("First Game Manager")]
    public ProjectileMovement PrefabProjectile;

    public static float abs(float x)
    {
        if (x < 0)
            return -x;
        return x;
    }

    Vector3 FindDirection()
    {

        Vector3 Archer = GameObject.FindGameObjectWithTag("ArcherPlayer").transform.position;
        Vector3 Guerrier = Archer;

        if (GameObject.FindGameObjectWithTag("KnightPlayer"))
        {
            Guerrier = GameObject.FindGameObjectWithTag("KnightPlayer").transform.position;
        }

        Vector3 Wiz = transform.position;
        Vector3 closer;
        Vector3 Direction;

        if (Vector3.Distance(Wiz, Archer) < Vector3.Distance(Wiz, Guerrier))
            closer = Archer;
        else
            closer = Guerrier;

        if (abs(abs(Wiz.x) - abs(closer.x)) < abs(abs(Wiz.z) - abs(closer.z)))
        {
            if (Wiz.x < closer.x)
            {
                Direction = new Vector3 (-1, 0, 0);
            }
            else
            {
                Direction = new Vector3(1, 0, 0);
            }
        }
        else
        {
            if (Wiz.z < closer.z)
            {
                Direction = new Vector3(0, 0, -1);
            }
            else
            {
                Direction = new Vector3(0, 0, 1);
                
            }
        }

        return Direction;

    }




    private void FixedUpdate()
    {
        if (compteurRT > ReloadTime)
        {
            ProjectileMovement.Createprojectile(ref projectile, ref PrefabProjectile, this.gameObject);
            compteurRT = 0;
        }
        else
        {
            compteurRT += 1;
        }
        Vector3 direction = Vector3.forward;

        if (compteurRD > ReloadDeplacement)
        {
            if (compteurDD > DureeDeplacement)
            {
                compteurDD = 0;
                compteurRD = 0;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else
            {
                if (compteurDD == 0)
                {
                    direction = FindDirection();
                    GetComponent<Rigidbody>().AddForce(direction * VitesseDeplacement);
                    compteurDD += 1;
                }
                else
                    compteurDD += 1;
            }
        }
        else
        {
            compteurRD += 1;
        }
    }

    public static GameObject SpawnWizzard(ref GameObject monster, ref WizGetAction PrefabWizzard, Vector3 Position)
    {
        if (PhotonNetwork.LocalPlayer.NickName == "Player 1")
        {
            GameObject Wizzard = PhotonNetwork.Instantiate(PrefabWizzard.gameObject.name, Position, Quaternion.identity);
            return Wizzard;
        }

        return null;
    }

}
