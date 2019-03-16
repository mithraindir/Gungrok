using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    GameObject objet;
    Rigidbody objetRB;
    public float strength;
    Vector3 directionKnockback;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            objet = other.gameObject;
            if (objet.tag == "ennemy")
            {
                if (other.contacts[0].thisCollider.gameObject.tag != "shield") //check if first point of contact is shield and if not remove health
                {
                    objetRB = objet.GetComponent<Rigidbody>();
                    directionKnockback = objet.transform.position - this.transform.position;
                    directionKnockback.Normalize();
                    objetRB.AddForce(directionKnockback * strength);
                }
            }
        }
    }
}
