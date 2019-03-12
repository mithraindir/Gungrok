using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DestructionOnContact : MonoBehaviourPun
{

    GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        projectile = this.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(projectile);
    }
}
