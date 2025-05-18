using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Buying : MonoBehaviour
{
    public bool ShopActive;

    public GameObject ShopUI;

    public GameObject GameUI;

    public Selling Selling;

    public PlayerCam playerCam;

    public Movement movement;

    public PlayerUI PlayerUI;

    public GameObject broke;

    public GameObject money;

    public GameObject playerUI;

    private float pastTime;

    private float closeTime;

    private float tempTime;

    public double AttackIncrement;
    public int HealthIncrement;
    public int StaminaIncrement;

    void Start()
    {
        money.SetActive(true);
        playerUI.SetActive(true);
        ShopActive = false;
        broke.SetActive(false);

        AttackIncrement = 1;
        HealthIncrement = 0;
        StaminaIncrement = 0;

        Selling.TotalMoney = 700;
        pastTime = 1;
        tempTime = 0;
    }

    
    void Update()
    {
        //Debug.Log(pastTime);
        //Debug.Log("Temp" + tempTime);
        pastTime += Time.deltaTime;
        closeTime += Time.deltaTime;
        if (closeTime >= 1.0)
        {
            broke.SetActive(false);
        }

        if (ShopActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerCam.enabled = false;
            Debug.Log("Temp: " + tempTime);       


            if(Input.GetKeyDown(KeyCode.X) && pastTime >= tempTime)
            {
                CloseShopUI();
            }
        }
        else
        {
            CloseShopUI();
        }
    }
    public void OpenShopUI()
    {
        ShopUI.SetActive(true);
        GameUI.SetActive(false);
        ShopActive = true;
        tempTime = pastTime + 1;
    }
    public void CloseShopUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ShopUI.SetActive(false);
        GameUI.SetActive(true);
        broke.SetActive(false);
        playerCam.enabled = true;
        ShopActive = false;
    }
    public void onMedKitClicked()
    {
        if(Selling.TotalMoney >= 150)
        {
            movement.Health = movement.MaxHealth;
            Selling.TotalMoney -= 150;
        }
        else
        {
            closeTime = 0;
            broke.SetActive(true);
        }
    }

    public void onHealthPotClicked()
    {
        if (Selling.TotalMoney >= 250)
        {
            movement.Health = movement.MaxHealth;
            Selling.TotalMoney -= 250;
        }
        else
        {
            closeTime = 0;
            broke.SetActive(true);
        }
    }

    public void onStaminaPotClicked()
    {
        if (Selling.TotalMoney >= 200)
        {
            movement.Health = movement.MaxHealth;
            Selling.TotalMoney -= 200;
        }
        else
        {
            closeTime = 0;
            broke.SetActive(true);
        }
    }

    public void onAttackClicked()
    {
        if(Selling.TotalMoney >= 550)
        {
            AttackIncrement += 0.1;
            Selling.TotalMoney -= 550;
        }
        else
        {
            closeTime = 0;
            broke.SetActive(true);
        }
    }

    public void onHealthClicked()
    {
        if (Selling.TotalMoney >= 500)
        {
            HealthIncrement += 1;
            Selling.TotalMoney -= 500;
        }
        else
        {
            closeTime = 0;
            broke.SetActive(true);
        }
    }

    public void onStaminaClicked()
    {
        if(Selling.TotalMoney >= 450)
        {
            StaminaIncrement += 1;
            Selling.TotalMoney -= 450;
        }
        else
        {
            closeTime = 0;
            broke.SetActive(true);
        }
    }
}
