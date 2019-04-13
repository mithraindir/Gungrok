using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootArrow : MonoBehaviourPun
{
    public float ReloadTime;
    float RT = 0;
    public GameObject Arrow;
 
    float compteur = 0;

    [Header("First Game Manager")]
    public ArrowMovement prefabArrow;




    // Update is called once per frame
    void FixedUpdate()
    {
        if (ArrowMovement.CreateArrow(ref Arrow, ref prefabArrow, ReloadTime, RT))
            RT = 0;
        else
            RT += 1;
        
    }

    
}
