using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MonoBehaviour
{
    private List<Rigidbody> EnnemyInWindAreaList = new List<Rigidbody>();
    public Vector3 windDirection;
    public float windStrength;

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
        if(EnnemyInWindAreaList.Count > 0)
        {
            //déplace tous les objet présent dans la zone vers l'extérieur
            foreach(Rigidbody ennemy in EnnemyInWindAreaList)
            {
                ennemy.velocity = (windDirection * windStrength);
            }
        }
    }
}
