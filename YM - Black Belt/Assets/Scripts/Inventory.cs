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
            itemcloned.transform.localScale = new Vector3(itemcloned.transform.localScale.x, itemcloned.transform.localScale.y, itemcloned.transform.localScale.z)/2;
            //itemcloned.transform.localRotation = Quaternion.Euler(-90, -90, 0);
            //itemcloned.transform.position = new Vector3(gameObject.transform.position.x + itemcloned.gameObject.GetComponent<IInteractable>().xOffset, gameObject.transform.position.y, gameObject.transform.position.z + itemcloned.gameObject.GetComponent<IInteractable>().zOffset);
        }

        else if(Input.GetKeyDown(KeyCode.Alpha1) && itemActive)
        {
            itemActive = false;
            itemcloned.SetActive(false);
        }

        if(itemActive)
        {
            itemcloned.transform.position = new Vector3(gameObject.transform.position.x + itemcloned.gameObject.GetComponent<IInteractable>().xOffset, gameObject.transform.position.y + itemcloned.gameObject.GetComponent<IInteractable>().yOffset, gameObject.transform.position.z + itemcloned.gameObject.GetComponent<IInteractable>().zOffset);
            itemcloned.transform.localRotation = Quaternion.Euler(0, 180, 90);
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
