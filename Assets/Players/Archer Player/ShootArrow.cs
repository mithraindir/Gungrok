using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootArrow : MonoBehaviourPun
{
    public float ReloadTime;
    
    public GameObject Arrow;
    

    float compteur = 0;

    [Header("First Game Manager")]
    public ArrowMovement prefabArrow;




    // Update is called once per frame
    void FixedUpdate()
    {
        

            ArrowMovement.CreateArrow(ref Arrow, ref prefabArrow);
            compteur = ReloadTime;
        
        
    }

    
}
