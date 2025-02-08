using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] InventorySlots;
    public GameObject[] Objects;

    public GameObject itemcloned;


    public bool itemActive;

    public Pickup Pickup;


    void Start()
    {
        itemActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !itemActive)
        {
            itemActive = true;
            itemcloned = Objects[0].gameObject;
            Objects[0].SetActive(true);
            itemcloned.transform.rotation = Quaternion.Euler(0, 180, 90);
            itemcloned.transform.position = new Vector3(gameObject.transform.position.x + itemcloned.gameObject.GetComponent<IInteractable>().xOffset, gameObject.transform.position.y + itemcloned.gameObject.GetComponent<IInteractable>().yOffset, gameObject.transform.position.z + itemcloned.gameObject.GetComponent<IInteractable>().zOffset);
        }

        else if(Input.GetKeyDown(KeyCode.Alpha1) && itemActive)
        {
            itemActive = false;
            itemcloned.SetActive(false);
        }

        if(itemActive)
        {
            
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
