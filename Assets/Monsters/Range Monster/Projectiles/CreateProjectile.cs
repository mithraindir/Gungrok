using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CreateProjectile : MonoBehaviourPun
{
    public static float abs(float x)
    {
        if (x < 0)
            return -x;
        return x;
    }

    Rigidbody projectile;
    public float ProjectileSpeed = 80;

    private void FixedUpdate()
    {
        projectile = GetComponent<Rigidbody>();
        projectile.AddForce(transform.forward * ProjectileSpeed);
    }

    public static void Createprojectile(ref GameObject projectile, ref CreateProjectile prefabProjectile, GameObject Tireur)
    {
        Vector3 pos = Tireur.transform.position;
        Vector3 Knight;
        Vector3 Archer = GameObject.FindGameObjectWithTag("ArcherPlayer").transform.position;
        if (GameObject.FindGameObjectWithTag("KnightPlayer"))
            Knight = GameObject.FindGameObjectWithTag("KnightPlayer").transform.position;
        else
            Knight = Archer;

        Vector3 closer;

        if (Vector3.Distance(Knight, pos) < Vector3.Distance(Archer, pos))
        {
            closer = Knight;
        }
        else
            closer = Archer;

        Quaternion orientation;
        Vector3 lieu = Tireur.transform.position;
        if (abs(abs(pos.x) - abs(closer.x)) > abs(abs(pos.z) - abs(closer.z)))
        {
            if (pos.x < closer.x)
            {
                lieu.x += 3;
                orientation = Quaternion.LookRotation(Vector3.right, Vector3.up);
            }
            else
            {
                lieu.x -= 3;
                orientation = Quaternion.LookRotation(Vector3.left, Vector3.up);
            }
        }
        else
        {
            if (pos.z < closer.z)
            {
                lieu.z += 3;
                orientation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            }
            else
            {
                lieu.z -= 3;
                orientation = Quaternion.LookRotation(Vector3.back, Vector3.up);
            }
        }

        projectile = PhotonNetwork.Instantiate(prefabProjectile.gameObject.name, lieu, orientation);
        
    }
}
