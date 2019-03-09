using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionOnContact : MonoBehaviour
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
