using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Shop_manager_knight : MonoBehaviourPun
{

    public int money;
    public GameObject ShopPrefab;
    GameObject player;
    Health PlayerHealth;
    ShielBash_circle PlayerSB;
    GameObject ShopUI;
    bool shopping;
    Button SBupgrade;
    Text SBCostText;
    int SBCost;
    Button HPupgrade;
    Text HPCostText;
    int HPCost;
    Text Money2display;
    GameObject SBDescription;
    GameObject HPDescription;

    // Start is called before the first frame update
    void Start()
    {
        SBCost = 50;
        HPCost = 500;
        shopping = false;
        player = GameObject.FindGameObjectWithTag("ArcherPlayer");
        PlayerHealth = player.GetComponent<Health>();
        PlayerSB = player.GetComponent<ShielBash_circle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.LocalPlayer.NickName != "Player 1") //for test purposes on not (!) to be removed
            return;

        if (!shopping && Input.GetKeyDown(KeyCode.M))
        {
            shopping = true;
            ShopUI = Instantiate(ShopPrefab); //creation of the Shop Ui and display 
            SBDescription = GameObject.FindGameObjectWithTag("SBDescription");
            HPDescription = GameObject.FindGameObjectWithTag("HPDescription");
            SBupgrade = GameObject.FindGameObjectWithTag("SBbutton").GetComponent<Button>();
            HPupgrade = GameObject.FindGameObjectWithTag("HPbutton").GetComponent<Button>();
            SBCostText = GameObject.FindGameObjectWithTag("SBPrice").GetComponent<Text>();
            SBCostText.text = "" + SBCost; //display of the correct price for SB upgrade
            HPCostText = GameObject.FindGameObjectWithTag("HPPrice").GetComponent<Text>();
            HPCostText.text = "" + HPCost; //display of the correct price for HP upgrade
            Money2display = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();
            Money2display.text = "" + money; //display of current balance
            player.SetActive(false); //deactivate the player so that it can no longer move
        }

        if (shopping)
        {


            //cheat to gain money
            if (Input.GetKeyDown(KeyCode.Alpha3))
                money += 100;

            if (Input.GetKeyDown(KeyCode.M))
            {
                shopping = false;
                Destroy(ShopUI);
                player.SetActive(true); //reactivate the player
            }
        }
    }
}
