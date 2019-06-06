using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject ESCMenu;
    public bool opened;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && opened == false)
        {
            Debug.Log("Menu Open");
            opened = true;
            ESCMenu.SetActive(true);

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && opened == true)
        {
            Debug.Log("Menu Close");
            ESCMenu.SetActive(false);
            opened = false;
        }
    }

    public void CloseMenu()
    {
        opened = false;
    }
}
