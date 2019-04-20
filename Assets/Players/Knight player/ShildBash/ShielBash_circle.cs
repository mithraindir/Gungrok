using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class ShielBash_circle : MonoBehaviourPun
{

    public GameObject windCircle_prefab;// |zones d'effet du shild bash
    GameObject windCircle;
    Slider shildBashSlider;  //le slider du cooldown du shield bash
    public float timerRef; //durée du cooldown
    public float effectTimeRef; //durée de shild bash (effet)
    float effectTime = 0;
    public float timer = 0f;
    bool effect = false;

    private void Start()
    {
        if (!photonView.IsMine)
            return;
        shildBashSlider = GameObject.FindGameObjectWithTag("shildBashSlider").GetComponent<Slider>();
        timer = timerRef;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!photonView.IsMine) //so that the other player don't activate this player's ability
            return;

        if (Input.GetKeyDown("space") && timer >= timerRef)
        {
            windCircle = PhotonNetwork.Instantiate(windCircle_prefab.gameObject.name, this.transform.position, Quaternion.identity, 0); //instantiate the windCircle and places it on the player
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
                PhotonNetwork.Destroy(windCircle); //remove the windcircle on all clients
                effect = false;
            }
        }
        //cooldown loop
        if (!effect && timer < timerRef)
            timer += Time.fixedDeltaTime;
        shildBashSlider.value = (timer / timerRef);
    }
}
