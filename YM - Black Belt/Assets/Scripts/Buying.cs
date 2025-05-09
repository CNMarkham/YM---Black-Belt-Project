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

    public Movement movement;

    public PlayerUI PlayerUI;

    public GameObject broke;

    public GameObject money;

    public GameObject playerUI;

    private float pastTime;

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
    }

    
    void Update()
    {
        pastTime += Time.deltaTime;
        if (pastTime >= 1.0)
        {
            broke.SetActive(false);
        }

        if (ShopActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ShopUI.SetActive(true);
            GameUI.SetActive(false);

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            ShopUI.SetActive(false);
            GameUI.SetActive(true);
            broke.SetActive(false);
        }
    }

    public void onMedKitClicked()
    {
        if(Selling.TotalMoney >= 150)
        {
            movement.Health = movement.MaxHealth;
        }
        else
        {
            pastTime = 0;
            broke.SetActive(true);
        }
    }

    public void onAttackClicked()
    {
        if(Selling.TotalMoney >= 550)
        {
            AttackIncrement += 0.1;
        }
        else
        {
            pastTime = 0;
            broke.SetActive(true);
        }
    }

    public void onHealthClicked()
    {
        if (Selling.TotalMoney >= 500)
        {
            HealthIncrement += 1;
        }
        else
        {
            pastTime = 0;
            broke.SetActive(true);
        }
    }

    public void onStaminaClicked()
    {
        if(Selling.TotalMoney >= 450)
        {
            StaminaIncrement += 1;
        }
        else
        {
            pastTime = 0;
            broke.SetActive(true);
        }
    }
}
