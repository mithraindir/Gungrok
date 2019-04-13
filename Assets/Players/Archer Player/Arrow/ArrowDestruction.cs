﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ArrowDestruction : MonoBehaviourPun
{
    GameObject projectile;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("ArcherPlayer") && !collision.gameObject.CompareTag("KnightPlayer"))
            Destroy(this.gameObject);
    }
}
