using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShielBash_circle : MonoBehaviour
{

    public GameObject windCircle;// |zones d'effet du shild bash
    public Slider shildBashSlider;  //le slider du cooldown du shield bash
    public float timerRef; //durée du cooldown
    public float effectTimeRef; //durée de shild bash (effet)
    float effectTime = 0;
    float timer = 0f;
    bool effect = false;

    private void Start()
    {
        timer = timerRef;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space") && timer >= timerRef)
        {
            windCircle.transform.position = this.transform.position;
            effectTime = 0; //réinitialise le temps d'effet
            timer = 0;//réinitialise le cooldown
            effect = true;
        }

        //effect time loop
        if (effect)
        {
            effectTime += Time.fixedDeltaTime;
            if (effectTime >= effectTimeRef)
            {
                effectTime = 0;
                windCircle.transform.position += new Vector3(0, 100, 0);
                effect = false;
            }
        }
        //cooldown loop
        if (!effect && timer < timerRef)
            timer += Time.fixedDeltaTime;

        //cheat to regain full timer 
        if (Input.GetKeyDown(KeyCode.Alpha2))
            timer = timerRef;

        shildBashSlider.value = (timer / timerRef);
    }
}
