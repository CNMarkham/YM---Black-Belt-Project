using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] InventorySlots;
    public GameObject[] Objects;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Objects[0].SetActive(true);
            //Objects[0]
        }
    }

    public bool AddtoInventory(GameObject ItemToAdd)
    {

        for (int i = 0; i < 4; i++)
        {

            if (Objects[i] == null)
            {
                Objects[i] = ItemToAdd;
                InventorySlots[i].GetComponent<Image>().sprite = ItemToAdd.GetComponent<ItemDetails>().ItemSprite;


                return true;
            }
        }
        return false;
    }
}
