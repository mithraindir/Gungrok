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
    ShootArrow PlayerArrow; //the player's health script
    Dash PlayerDash; //the player's SB script
    GameObject ShopUI; //the shop UI which is shown/instantiated
    bool shopping; //to know if the shop panel/UI is activated/instantiated
    Button Dashupgrade; //the button to upgrade the SB
    Text DashCostText;
    Text CurrentDashTimer;
    int DashCost; //the cost of the upgrade shown on the button
    Button Arrowupgrade; //the button to upgrade the HP
    Text ArrowCostText;
    Text CurrentArrow;
    int ArrowCost; //the cost of the upgrade shown on the button
    Text Money2display; //the balnce shown in text form
    GameObject DashDescription; //the description of the SB upgrade
    GameObject ArrowDescription; //the description of the HP upgrade

    // Start is called before the first frame update
    void Start()
    {
        DashCost = 50;
        ArrowCost = 500;
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
            PlayerArrow = player.GetComponent<ShootArrow>();
            PlayerDash = player.GetComponent<Dash>();
            shopping = true;
            ShopUI = Instantiate(ShopPrefab); //creation of the Shop Ui and display 
            DashDescription = GameObject.FindGameObjectWithTag("DashDescription");
            ArrowDescription = GameObject.FindGameObjectWithTag("ShootDescription");
            Dashupgrade = GameObject.FindGameObjectWithTag("DashButton").GetComponent<Button>();
            Dashupgrade.onClick.AddListener(DashButtonClick);
            Arrowupgrade = GameObject.FindGameObjectWithTag("ShootButton").GetComponent<Button>();
            Arrowupgrade.onClick.AddListener(ArrowButtonClick);
            DashCostText = GameObject.FindGameObjectWithTag("DashPrice").GetComponent<Text>();
            DashCostText.text = "" + DashCost; //display of the correct price for SB upgrade
            CurrentDashTimer = GameObject.FindGameObjectWithTag("DashTimer").GetComponent<Text>();
            CurrentDashTimer.text = PlayerDash.timerRef + " seconds"; //update the current cooldown display
            ArrowCostText = GameObject.FindGameObjectWithTag("ShootPrice").GetComponent<Text>();
            ArrowCostText.text = "" + ArrowCost; //display of the correct price for HP upgrade
            CurrentArrow = GameObject.FindGameObjectWithTag("ReloadTime").GetComponent<Text>();
            CurrentArrow.text = PlayerArrow.ReloadTime + " seconds";
            Money2display = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();
            Money2display.text = "" + money; //display of current balance
            player.GetComponent<PlayerMovement>().enabled = false;
            PlayerArrow.enabled = false;
            PlayerDash.enabled = false;
            //player.SetActive(false); //deactivate the player so that it can no longer move
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
                    Arrowupgrade.onClick.RemoveListener(ArrowButtonClick);
                    Destroy(ShopUI);
                    player.GetComponent<PlayerMovement>().enabled = true;
                    PlayerArrow.enabled = true;
                    PlayerDash.enabled = true;
                    //player.SetActive(true); //reactivate the player
                }

                if (PlayerDash.timerRef == 2) //maximum value of Dash cooldown
                {
                    Dashupgrade.interactable = false;
                    DashCostText.text = "NO MORE UPGRADES";
                }

                if (PlayerArrow.ReloadTime == 2) //maximum value of reload time
                {
                    Arrowupgrade.interactable = false;
                    ArrowCostText.text = "NO MORE UPGRADES";
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

    void ArrowButtonClick() //called when HP Button is clicked
    {
        if (ArrowCost > money)
            return;
        money -= ArrowCost; //remove the correct amount of money from the player's balance
        ArrowCost += 250; //raise of the upgrade cost
        Money2display.text = "" + money;
        ArrowCostText.text = "" + ArrowCost;
        PlayerArrow.ReloadTime -= 2;
        CurrentArrow.text = PlayerArrow.ReloadTime + " seconds";
    }

    void HPButtonMouseOver() //called when the mouse is over the HP Button
    {

    }

    void HPButtonMouseExit() //called when the mouse leaves the HP Button
    {

    }
}
