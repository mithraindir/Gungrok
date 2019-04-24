using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;

   
    public bool IsClosed = false;

    private void OnTriggerEnter(Collider collision)
    {

        if (!IsClosed)
        {
            if (collision.gameObject.tag == "ArcherPlayer")
            {
                //tp le guerrier sur l'archer
                if (GameObject.FindGameObjectWithTag("KnightPlayer"))
                {
                    GameObject.FindGameObjectWithTag("KnightPlayer").transform.position = collision.gameObject.transform.position;
                }

                Door1.GetComponent<MeshRenderer>().enabled = true;
                Door2.GetComponent<MeshRenderer>().enabled = true;

                Door1.GetComponent<MeshCollider>().enabled = true;
                Door2.GetComponent<MeshCollider>().enabled = true;
                IsClosed = true;

            }
            else
            {
                if (collision.gameObject.tag == "KnightPlayer")
                {
                    //tp le guerrier sur l'archer
                    if (GameObject.FindGameObjectWithTag("ArcherPlayer"))
                    {
                        GameObject.FindGameObjectWithTag("ArcherPlayer").transform.position = collision.gameObject.transform.position;
                    }

                    Door1.GetComponent<MeshRenderer>().enabled = true;
                    Door2.GetComponent<MeshRenderer>().enabled = true;

                    Door1.GetComponent<MeshCollider>().enabled = true;
                    Door2.GetComponent<MeshCollider>().enabled = true;
                    IsClosed = true;

                }
            }


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

                Door1.GetComponent<MeshCollider>().enabled = false;
                Door2.GetComponent<MeshCollider>().enabled = false;


            }
        }
    }


}
