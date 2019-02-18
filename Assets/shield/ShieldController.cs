using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    float MoveX = 0;
    float MoveZ = 0;
    int orientation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (MoveZ == 0)
        {
            MoveX = Input.GetAxisRaw("HorizontalFR");
            if (MoveX == 1)
                orientation = 90;
            if (MoveX == -1)
                orientation = -90;
        }
        if (MoveX == 0)    //to see axis go to edit->project settings->input
        {                       
            MoveZ = Input.GetAxisRaw("VerticalFR");
            if (MoveZ == 1)
                orientation = 0;
            if (MoveZ == -1)
                orientation = 180;
        }
    }
}
