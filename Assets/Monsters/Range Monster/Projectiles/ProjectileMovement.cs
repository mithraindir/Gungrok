using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    Rigidbody projectile;
    public float ProjectileSpeed;

    private void FixedUpdate()
    {
            projectile = GetComponent<Rigidbody>();
            projectile.AddForce(transform.forward * ProjectileSpeed);
    }
}
