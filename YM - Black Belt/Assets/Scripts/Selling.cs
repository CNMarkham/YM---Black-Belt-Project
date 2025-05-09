using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selling : MonoBehaviour
{
    public Inventory Inventory;

    private int price;

    public int TotalMoney;

    public Text Money;

    void Start()
    {
           
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Object")
        {
            if (collision.gameObject.GetComponent<Crowbar>() != null)
            {
                Debug.Log("Collision Occurs");
                price = collision.gameObject.GetComponent<Crowbar>().itemPrice;
                Destroy(collision.gameObject);
                TotalMoney = TotalMoney + price;
                Money.text = "$" + TotalMoney;
            }
            //else if ()
            //{

            //}
        }
    }
}
