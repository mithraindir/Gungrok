using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorChange : MonoBehaviour
{
    Slider slider;
    GameObject fillSlider;
    GameObject fillOutside;
    Image fillImageSlider;
    Image fillImageOutside;
    public Color ReadyColorSlider;
    public Color ChargingColorSlider;
    public Color ReadyColorOutside;
    public Color CharginngColorOutside;

    private void Start()
    {
        slider = GetComponent<Slider>();
        fillSlider = slider.transform.GetChild(1).GetChild(0).gameObject; //grab the transform of 2nd child of slider("Fill area"), grab 1st child of that transform(Fill)
        fillOutside = slider.transform.GetChild(0).gameObject; //grab outside of slider
        fillImageSlider = fillSlider.GetComponent<Image>();//grab his image compenent
        fillImageOutside = fillOutside.GetComponent<Image>();//grab image compenent
    }

    private void Update()
    {
        if (slider.value >= 1)
        {
            fillImageSlider.color = ReadyColorSlider; //slider color when full
            fillImageOutside.color = ReadyColorOutside;//outside color when full
        }
        else
        {
            fillImageSlider.color = ChargingColorSlider; //slider color when not full
            fillImageOutside.color = CharginngColorOutside; //outside color when not full
        }

    }
}
