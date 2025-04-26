using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buying : MonoBehaviour
{
    public bool ShopActive;

    public GameObject ShopUI;

    public GameObject GameUI;

    public Selling Selling;

    public Movement movement;

    public PlayerUI PlayerUI;

    void Start()
    {
        ShopActive = false;
    }

    
    void Update()
    {
        if(ShopActive)
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
        }
    }

    public void onMedKitClicked()
    {
        if(Selling.TotalMoney >= 150)
        {
            movement.Health = movement.MaxHealth;
        }
    }
}
