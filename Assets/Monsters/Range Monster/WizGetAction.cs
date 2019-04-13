using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizGetAction : MonoBehaviour
{
    public float ReloadTime = 200;
    float compteurRT = 0;


    public float DureeDeplacement = 200;
    public float ReloadDeplacement = 800;
    float compteurDD = 0;
    float compteurRD = 0;

    public GameObject projectile;
    [Header("First Game Manager")]
    public CreateProjectile PrefabProjectile;
    

    private void FixedUpdate()
    {
        if (compteurRT > ReloadTime)
        {
            CreateProjectile.Createprojectile(ref projectile, ref PrefabProjectile, this.gameObject);
            compteurRT = 0;
        }
        else
        {
            compteurRT += 1;
        }


    }
}
