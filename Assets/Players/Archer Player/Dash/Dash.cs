using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Dash : MonoBehaviourPun
{
    Slider DashSlider;  //le slider du cooldown du shield bash
    PlayerMovement PMov;
    public float timerRef; //durée du cooldown
    public float effectTimeRef; //durée de shild bash (effet)
    float effectTime = 0;
    public float speed = 50;
    public float timer = 0f;
    bool effect = false;

    private void Start()
    {
        PMov = this.GetComponent<PlayerMovement>();
        DashSlider = GameObject.FindGameObjectWithTag("shildBashSlider").GetComponent<Slider>();
        timer = timerRef;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!photonView.IsMine) //so that the other player don't activate this player's ability
            return;

        if (Input.GetKeyDown(KeyCode.Space) && timer >= timerRef)
        {
            this.GetComponent<Rigidbody>().velocity = speed * transform.forward.normalized;
            effectTime = 0; //réinitialise le temps d'effet
            timer = 0f;//réinitialise le cooldown
            PMov.enabled = false;
            effect = true;
        }
        
        //cheat to regain full timer 
        if (Input.GetKeyDown(KeyCode.Alpha2))
            timer = timerRef;

        //effect time loop
        if (effect)
        {
            effectTime += Time.fixedDeltaTime;
            if (effectTime >= effectTimeRef)
            {
                effectTime = 0;
                this.GetComponent<Rigidbody>().velocity = new Vector3 (0,0,0);
                PMov.enabled = true;
                effect = false;
            }
        }
        //cooldown loop
        if (!effect && timer < timerRef)
            timer += Time.fixedDeltaTime;
        DashSlider.value = (timer / timerRef);
    }
}


