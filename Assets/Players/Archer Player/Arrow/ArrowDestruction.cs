using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ArrowDestruction : MonoBehaviourPun
{
    GameObject projectile;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
