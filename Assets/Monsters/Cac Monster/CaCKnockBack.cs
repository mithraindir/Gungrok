using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaCKnockBack : MonoBehaviour
{
    //Force is the strengh of the knock back
    public float force;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "KnightPlayer" || collision.gameObject.tag == "ArcherPlayer")
        {
            //determine the vector zombie --> collision point
            Vector3 direction = collision.contacts[0].point - transform.position;

            //invert it and normalize it
            direction = -direction.normalized;
            
            //apply it to the rigidbody
            GetComponent<Rigidbody>().AddForce(direction * force);
        }
    }
}
