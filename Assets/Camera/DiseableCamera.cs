using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseableCamera : MonoBehaviour
{
    public GameObject player;
    public Camera camera;

    //verifie que la zone de trigger à été activé...
    private void OnTriggerEnter(Collider collision)
    {
        //...par le player
        if (collision.gameObject.tag == player.tag)
        {
            camera.enabled = false;
        }
    }
}
