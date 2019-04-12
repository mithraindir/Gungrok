using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaCMonsterMovement : MonoBehaviourPun
{
    //movement speed
    public float speed;
    
    GameObject knight;
    GameObject archer;

    Vector3 Vector3Knight;
    Vector3 VectorMonster;
    Vector3 Vector3Archer;

    Rigidbody PrefabZombie;
    private Rigidbody monster;

    private float Abs (float x)
    {
        if (x > 0)
            return x;
        return -x;
    }
   
    // Start is called before the first frame update
    void Start()
    {
        //monster object
        monster = GetComponent<Rigidbody>();

        //get players (for coordinates)
        archer = GameObject.FindGameObjectWithTag("ArcherPlayer");
        knight = GameObject.FindGameObjectWithTag("KnightPlayer");


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (knight == null)
        {
            knight = GameObject.FindGameObjectWithTag("KnightPlayer");
            Vector3Knight = archer.transform.position;
        }
        else
        {
            //knight's coordinates
            Vector3Knight = knight.transform.position;
        }

        //monster's coordinates
        VectorMonster = monster.transform.position;

     
        
       

        //archer's coordinates
        Vector3Archer = archer.transform.position;
        

        //get the closest one
        Vector3 Closer;
        if (Vector3.Distance(Vector3Archer, VectorMonster) < Vector3.Distance(Vector3Knight, VectorMonster))
        {
            Closer = Vector3Archer;
        }
        else
            Closer = Vector3Knight;



        //Move to the closest direction
        if (Abs(Abs(Closer.x) - Abs(VectorMonster.x)) > Abs(Abs(Closer.z) - Abs(VectorMonster.z)))
        {
            if (Closer.x < VectorMonster.x)
                monster.velocity = new Vector3(-speed, 0, 0);
            else
                monster.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            if (Closer.z < VectorMonster.z)
                monster.velocity = new Vector3(0, 0, -speed);
            else
                monster.velocity = new Vector3(0, 0, speed);
        }


    }

    public static void SpawnZombie( ref GameObject monster, ref CaCMonsterMovement PrefabZombie)
    {
        var PosZombie = new Vector3(134.8f, 0.1f, 5.208689f);
        if (PhotonNetwork.LocalPlayer.NickName == "Player 1")
            monster = PhotonNetwork.Instantiate(PrefabZombie.gameObject.name, PosZombie, Quaternion.identity);
    }
}
