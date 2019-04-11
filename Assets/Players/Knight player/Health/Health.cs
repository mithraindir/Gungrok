using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider HealthSlider;
    int lifeRef;
    int life;
    GameObject objet;

    private void Start()
    {
        lifeRef = 3;
        life = 3;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            objet = other.gameObject;
            if (objet.tag == "ennemy")
            {
                if (other.contacts[0].thisCollider.gameObject.tag != "shield") //check if first point of contact is shild and if not remove health
                {
                    life -= 1;
                }
            }
        }
}

    private void FixedUpdate()
    {
        HealthSlider.value = life;

        if (life <= 0)
        {
            Debug.Log("DEATH");
        }

        //cheat to regain life
        if (Input.GetKeyDown(KeyCode.Alpha1))
            life = lifeRef;
    }
}
