using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShielBash : MonoBehaviour
{
    public GameObject Top;    //|
    public GameObject bottom;// |zones d'effet du shild bash
    public GameObject right;//  |
    public GameObject left;//   |
    public Slider shildBashSlider;  //le slider du cooldown du shield bash
    public float timerRef;
    bool effect = false;
    public float effectTimeRef;
    float effectTime = 0;
    float timer = 0f;

    private void Start()
    {
        timer = timerRef;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space") && timer >= timerRef)
        {
            Top.transform.position = transform.position + (new Vector3(0, 0, 4));
            bottom.transform.position = transform.position + (new Vector3(0, 0, -4));
            right.transform.position = transform.position + (new Vector3(5, 0, 0));
            left.transform.position = transform.position + (new Vector3(-5, 0, 0));

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
                Top.transform.position += (new Vector3(0, 100, 0));
                bottom.transform.position += (new Vector3(0, 100, 0));
                right.transform.position += (new Vector3(0, 100, 0));
                left.transform.position += (new Vector3(0, 100, 0));
                effect = false;
            }
        }
        if (!effect && timer < timerRef)
            timer += Time.fixedDeltaTime;

        shildBashSlider.value = (timer / timerRef);
    }
}
