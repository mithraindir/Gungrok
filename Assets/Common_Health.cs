using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Health : MonoBehaviour
{
    public float Health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Health = this.transform.position.x;
    }
}
