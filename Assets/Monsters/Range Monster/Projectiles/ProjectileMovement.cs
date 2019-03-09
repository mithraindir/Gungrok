using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    Rigidbody projectile;
    public float ProjectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // on le fait bouger tout droit
        projectile.AddForce(transform.forward * ProjectileSpeed);
    }
}
