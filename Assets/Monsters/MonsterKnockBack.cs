using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKnockBack : MonoBehaviour
{
    //Force determines how far the monster is pushed
    public float force;

    private void OnCollisionEnter(Collision collision)
    {
        //determine if the object hit is a player
        if(collision.gameObject.tag == "KnightPlayer" || collision.gameObject.tag == "ArcherPlayer")
        {
            //calculate angle between this and collision
            Vector3 dir = collision.contacts[0].point - transform.position;

            //invert it then normalize it
            dir = -dir.normalized;

            //push this with the vector
            GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }
}
