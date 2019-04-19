using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect_Circle : MonoBehaviour
{
    private List<Rigidbody> EnnemyInWindAreaList = new List<Rigidbody>();
    public float windStrength;
    private Vector3 windDirection = new Vector3(0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        //obtention du rigidbody de l'objet entrant dans la zone 
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            Rigidbody objectRigid = other.gameObject.GetComponent<Rigidbody>();
            //si il s'agit d'un ennemy on l'ajoute à la liste 
            if (objectRigid.tag == "ennemy")
                EnnemyInWindAreaList.Add(objectRigid);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //obtention du gigidbody de l'objet sortant de la zone
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            Rigidbody objectRigid = other.gameObject.GetComponent<Rigidbody>();
            //si il s'agit d'un ennemy on le retire de la liste et lui retire la force
            if (objectRigid.tag == "ennemy")
            {
                EnnemyInWindAreaList.Remove(objectRigid);
                objectRigid.velocity = new Vector3(0, 0, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        if (EnnemyInWindAreaList.Count > 0)
        {
            //move all object in circle toward the outside
            foreach (Rigidbody ennemy in EnnemyInWindAreaList)
            {
                windDirection = ennemy.transform.position - this.transform.position; //a vector is created between going from the center of the circle to ennemy
                windDirection.Normalize(); //the vector is normalized to apply the same force to all (close or not)
                ennemy.velocity = (windDirection * windStrength);
            }
        }
    }
}
