using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateShopManager : MonoBehaviour
{

    public GameObject ShopManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject manager = Instantiate(ShopManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
