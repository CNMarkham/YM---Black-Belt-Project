using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject[] InventorySlots;
    public GameObject[] Objects;
    //public List<GameObject> Objects = new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {
        
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
