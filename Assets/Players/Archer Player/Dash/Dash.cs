using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Dash : MonoBehaviourPun
{
    Slider DashSlider;  //le slider du cooldown du shield bash
    public float timerRef; //durée du cooldown
    public float effectTimeRef; //durée de shild bash (effet)
    float effectTime = 0;
    public float timer = 0f;
    bool effect = false;

    private void Start()
    {
        if (!photonView.IsMine)
            return;
        DashSlider = GameObject.FindGameObjectWithTag("shildBashSlider").GetComponent<Slider>();
        timer = timerRef;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!photonView.IsMine) //so that the other player don't activate this player's ability
            return;

        if (Input.GetKeyDown("space") && timer >= timerRef)
        {
            effectTime = 0; //réinitialise le temps d'effet
            timer = 0f;//réinitialise le cooldown
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
                effect = false;
            }
        }
        //cooldown loop
        if (!effect && timer < timerRef)
            timer += Time.fixedDeltaTime;
        DashSlider.value = (timer / timerRef);
    }
}


