using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHealth : MonoBehaviour
{
    public float HealthPoint = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ArcherProjectile"))
            HealthPoint -= 1;
        if (HealthPoint == 0)
            Destroy(this.gameObject);
    }
}
