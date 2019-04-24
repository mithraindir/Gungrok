using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Shop_manager_archer : MonoBehaviourPun
{

    public int money; //the player's current balance
    public GameObject ShopPrefab; //the shop ui prefab
    GameObject player = null;
    Health PlayerHealth; //the player's health script
    Dash PlayerDash; //the player's SB script
    GameObject ShopUI; //the shop UI which is shown/instantiated
    bool shopping; //to know if the shop panel/UI is activated/instantiated
    Button Dashupgrade; //the button to upgrade the SB
    Text DashCostText;
    Text CurrentDashTimer;
    int DashCost; //the cost of the upgrade shown on the button
    Button HPupgrade; //the button to upgrade the HP
    Text HPCostText;
    Text CurrentHP;
    int HPCost; //the cost of the upgrade shown on the button
    Text Money2display; //the balnce shown in text form
    GameObject DashDescription; //the description of the SB upgrade
    GameObject HPDescription; //the description of the HP upgrade

    // Start is called before the first frame update
    void Start()
    {
        DashCost = 50;
        HPCost = 500;
        shopping = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PhotonNetwork.LocalPlayer.NickName != "Player 1") 
            return;

        if (Input.GetKeyDown(KeyCode.M) && !shopping)
        {
            player = GameObject.FindGameObjectWithTag("ArcherPlayer");
            PlayerHealth = player.GetComponent<Health>();
            PlayerDash = player.GetComponent<Dash>();
            shopping = true;
            ShopUI = Instantiate(ShopPrefab); //creation of the Shop Ui and display 
            DashDescription = GameObject.FindGameObjectWithTag("DashDescription");
            HPDescription = GameObject.FindGameObjectWithTag("HPDescription");
            Dashupgrade = GameObject.FindGameObjectWithTag("DashButton").GetComponent<Button>();
            Dashupgrade.onClick.AddListener(DashButtonClick);
            HPupgrade = GameObject.FindGameObjectWithTag("HPbutton").GetComponent<Button>();
            HPupgrade.onClick.AddListener(HPButtonClick);
            DashCostText = GameObject.FindGameObjectWithTag("DashPrice").GetComponent<Text>();
            DashCostText.text = "" + DashCost; //display of the correct price for SB upgrade
            CurrentDashTimer = GameObject.FindGameObjectWithTag("SBTimer").GetComponent<Text>();
            CurrentDashTimer.text = PlayerDash.timerRef + " seconds"; //update the current cooldown display
            HPCostText = GameObject.FindGameObjectWithTag("HPPrice").GetComponent<Text>();
            HPCostText.text = "" + HPCost; //display of the correct price for HP upgrade
            CurrentHP = GameObject.FindGameObjectWithTag("HP").GetComponent<Text>();
            CurrentHP.text = PlayerHealth.lifeRef + " HP";
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
                    money += 100000;
                    Money2display.text = "" + money;
                }

                if (Input.GetKeyDown(KeyCode.M))
                {
                    shopping = false;
                    Dashupgrade.onClick.RemoveListener(DashButtonClick);
                    //HPupgrade.onClick.RemoveListener(SBButtonClick);
                    Destroy(ShopUI);
                    player.SetActive(true); //reactivate the player
                }

                if (PlayerDash.timerRef == 2)
                {
                    Dashupgrade.interactable = false;
                    DashCostText.text = "NO MORE UPGRADES";
                }
            }
        }


    }

    void DashButtonClick() //called when SB Button is clicked
    {
        if (DashCost > money)
        {
            return;
        }
        money -= DashCost; //remove the correct amount of money from the player's balance
        DashCost += 100; //raise of the upgrade cost
        Money2display.text = "" + money;
        DashCostText.text = "" + DashCost;
        PlayerDash.timerRef -= 2; //reduction of the shildBash cooldown
        PlayerDash.timer = PlayerDash.timerRef;
        CurrentDashTimer.text = PlayerDash.timerRef + " seconds";
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
        CurrentHP.text = PlayerHealth.lifeRef + " HP";
    }

    void HPButtonMouseOver() //called when the mouse is over the HP Button
    {

    }

    void HPButtonMouseExit() //called when the mouse leaves the HP Button
    {

    }
}
