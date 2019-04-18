using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;

   
    public bool IsClosed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsClosed)
        {

            Door1.GetComponent<MeshRenderer>().enabled = true;
            Door2.GetComponent<MeshRenderer>().enabled = true;

            Door1.GetComponent<BoxCollider>().enabled = true;
            Door2.GetComponent<BoxCollider>().enabled = true;
            IsClosed = true;
        }
    }

    private void FixedUpdate()
    {
        
        if (IsClosed)
        {
            if (MonsterList.IsEmpty())
            {
                Door1.GetComponent<MeshRenderer>().enabled = false;
                Door2.GetComponent<MeshRenderer>().enabled = false;

                Door1.GetComponent<BoxCollider>().enabled = false;
                Door2.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }


}
