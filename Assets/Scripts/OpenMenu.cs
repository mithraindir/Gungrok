using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject ESCMenu;
    public bool opened;

    void Start()
    {
        opened = false;  
    }
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
        else if (Input.GetKeyDown(KeyCode.O) && opened == true)
        {
            Quit();
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
