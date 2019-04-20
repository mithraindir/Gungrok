using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Shop_manager_knight : MonoBehaviourPun
{

    public int money; //the player's current balance
    public GameObject ShopPrefab; //the shop ui prefab
    GameObject player = null; 
    Health PlayerHealth; //the player's health script
    ShielBash_circle PlayerSB; //the player's SB script
    GameObject ShopUI; //the shop UI which is shown/instantiated
    bool shopping; //to know if the shop panel/UI is activated/instantiated
    Button SBupgrade; //the button to upgrade the SB
    Text SBCostText;
    int SBCost; //the cost of the upgrade shown on the button
    Button HPupgrade; //the button to upgrade the HP
    Text HPCostText;
    int HPCost; //the cost of the upgrade shown on the button
    Text Money2display; //the balnce shown in text form
    GameObject SBDescription; //the description of the SB upgrade
    GameObject HPDescription; //the description of the HP upgrade

    // Start is called before the first frame update
    void Start()
    {
        SBCost = 50;
        HPCost = 500;
        shopping = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PhotonNetwork.LocalPlayer.NickName != "Player 1") //for test purposes on not (!) to be removed
            return;

        if (Input.GetKeyDown(KeyCode.M) && !shopping)
        {
            player = GameObject.FindGameObjectWithTag("ArcherPlayer");
            PlayerHealth = player.GetComponent<Health>();
            PlayerSB = player.GetComponent<ShielBash_circle>();
            shopping = true;
            ShopUI = Instantiate(ShopPrefab); //creation of the Shop Ui and display 
            SBDescription = GameObject.FindGameObjectWithTag("SBDescription");
            HPDescription = GameObject.FindGameObjectWithTag("HPDescription");
            SBupgrade = GameObject.FindGameObjectWithTag("SBbutton").GetComponent<Button>();
            SBupgrade.onClick.AddListener(SBButtonClick);
            HPupgrade = GameObject.FindGameObjectWithTag("HPbutton").GetComponent<Button>();
            HPupgrade.onClick.AddListener(HPButtonClick);
            SBCostText = GameObject.FindGameObjectWithTag("SBPrice").GetComponent<Text>();
            SBCostText.text = "" + SBCost; //display of the correct price for SB upgrade
            HPCostText = GameObject.FindGameObjectWithTag("HPPrice").GetComponent<Text>();
            HPCostText.text = "" + HPCost; //display of the correct price for HP upgrade
            Money2display = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();
            Money2display.text = "" + money; //display of current balance
            player.SetActive(false); //deactivate the player so that it can no longer move
        }
        else
        {
            if (shopping)
            {
                //cheat to gain money
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    money += 100;
                    Money2display.text = "" + money;
                }

                if (Input.GetKeyDown(KeyCode.M))
                {
                    shopping = false;
                    SBupgrade.onClick.RemoveListener(SBButtonClick);
                    HPupgrade.onClick.RemoveListener(SBButtonClick);
                    Destroy(ShopUI);
                    player.SetActive(true); //reactivate the player
                }
            }
        }
        

    }

    void SBButtonClick() //called when SB Button is clicked
    {
        if (SBCost > money)
            return;
        money -= SBCost; //remove the correct amount of money from the player's balance
        SBCost += 100; //raise of the upgrade cost
        Money2display.text = "" + money;
        SBCostText.text = "" + SBCost;
        PlayerSB.timerRef -= 2; //reduction of the shildBash cooldown
        PlayerSB.timer = PlayerSB.timerRef;
    }

    void SBButtonMouseOver() //called when the mouse is over the SB Button
    {

    }

    void SBButtonMouseExit() //called when the mouse leaves the SB Button
    {

    }

    void HPButtonClick() //called when HP Button is clicked
    {
        if (HPCost > money)
            return;
        money -= HPCost; //remove the correct amount of money from the player's balance
        HPCost += 250; //raise of the upgrade cost
        Money2display.text = "" + money;
        HPCostText.text = "" + HPCost;
        PlayerHealth.lifeRef += 1;
        PlayerHealth.upgrade = true;
    }

    void HPButtonMouseOver() //called when the mouse is over the HP Button
    {

    }

    void HPButtonMouseExit() //called when the mouse leaves the HP Button
    {

    }
}
