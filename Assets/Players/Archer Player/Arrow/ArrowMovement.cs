using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ArrowMovement : MonoBehaviourPun
{
    
    public float ProjectileSpeed;
    
    

    
    // Update is called once per frame
    void FixedUpdate()
    {

            GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileSpeed);
    }

    public static bool CreateArrow(ref GameObject Arrow, ref ArrowMovement prefabArrow, float ReloadTime, float RT)
    { 

        float MoveX = 0;
        float MoveZ = 0;
        Vector3 vect;
        GameObject Archer = GameObject.FindGameObjectWithTag("ArcherPlayer");

        if (RT >= ReloadTime)
        {
            if (PhotonNetwork.LocalPlayer.NickName == "Player 1")
            {
                if (Input.GetAxisRaw("PrimaryX") != 0 || Input.GetAxisRaw("PrimaryZ") != 0)
                {

                    if (MoveZ == 0)
                        MoveX = Input.GetAxisRaw("PrimaryX");
                    if (MoveX == 0)
                        MoveZ = Input.GetAxisRaw("PrimaryZ");

                    vect = new Vector3(MoveX, 0, MoveZ);

                    PhotonNetwork.Instantiate(prefabArrow.gameObject.name, Archer.transform.position + vect, Quaternion.LookRotation(vect, Vector3.up));
                    

                    return true;
                }
            }
        }
        return false;
    }
}
