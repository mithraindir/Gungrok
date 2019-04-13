using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ArrowMovement : MonoBehaviourPun
{
    Rigidbody projectile;
    public float ProjectileSpeed;

    
    float Speed;
    

    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!projectile)
            projectile = GetComponent<Rigidbody>();

        // on le fait bouger tout droit
        projectile.AddForce(transform.forward * ProjectileSpeed);
    }

    public static bool CreateArrow(ref GameObject Arrow, ref ArrowMovement prefabArrow, float ReloadTime, float RT)
    { 

        float MoveX = 0;
        float MoveZ = 0;
        Vector3 vect;
        GameObject Archer = GameObject.FindGameObjectWithTag("ArcherPlayer");

        if (RT >= ReloadTime)
        {
            if (Input.GetAxisRaw("PrimaryX") != 0 || Input.GetAxisRaw("PrimaryZ") != 0)
            {
                
                if (MoveZ == 0)
                    MoveX = Input.GetAxisRaw("PrimaryX");
                if (MoveX == 0)
                    MoveZ = Input.GetAxisRaw("PrimaryZ");

                vect = new Vector3(MoveX, 0, MoveZ);

                Arrow = PhotonNetwork.Instantiate(prefabArrow.gameObject.name, vect, Quaternion.LookRotation(vect, Vector3.up));
                Arrow.transform.position = Archer.transform.position + 2 * Arrow.transform.forward;
                return true;
            }
        }
        return false;
    }
}
