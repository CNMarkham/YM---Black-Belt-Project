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

    public GameObject campos;

    public GameObject MainCamera;

    public bool itemActive;

    public int itemNumber;

    public Pickup Pickup;

    private Animator animator;

    public GameObject ItemHandler;

    public GameObject crowbar;


    void Start()
    {
        itemActive = false;

        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !itemActive && Objects[0] != null)
        {
            itemActive = true;
            itemNumber = 0;
            Vector3 newDirection = new Vector3(campos.transform.position.x, campos.transform.position.y, campos.transform.position.z);
            itemcloned = Instantiate(crowbar.gameObject, newDirection, Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90));
            itemcloned.transform.localScale = new Vector3(itemcloned.transform.localScale.x * 8, itemcloned.transform.localScale.y * 8, itemcloned.transform.localScale.z * 8) / 2;
            itemcloned.gameObject.transform.parent = ItemHandler.transform;
            itemcloned.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && itemActive)
        {
            itemActive = false;
            itemNumber = 7;
            Destroy(itemcloned);
            Debug.Log("Destroyed held-hand");
        }
        else if(itemActive == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Destroy(itemcloned);
                itemActive = false;
                Objects[itemNumber].SetActive(true);
                Objects[itemNumber].transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
                Objects[itemNumber].GetComponent<Rigidbody>().isKinematic = false;
                Objects[itemNumber] = null;
                InventorySlots[itemNumber].GetComponent<Image>().sprite = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !itemActive && Objects[1] != null)
        {
            itemActive = true;
            itemNumber = 1;
            Vector3 newDirection = new Vector3(campos.transform.position.x, campos.transform.position.y, campos.transform.position.z);
            itemcloned = Instantiate(crowbar.gameObject, newDirection, Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90));
            itemcloned.transform.localScale = new Vector3(itemcloned.transform.localScale.x * 8, itemcloned.transform.localScale.y * 8, itemcloned.transform.localScale.z * 8) / 2;
            itemcloned.gameObject.transform.parent = ItemHandler.transform;
            itemcloned.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && itemActive)
        {
            itemActive = false;
            itemNumber = 7;
            Destroy(itemcloned);
        }
        else if (itemActive == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Destroy(itemcloned);
                itemActive = false;
                Objects[itemNumber].SetActive(true);
                Objects[itemNumber].transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
                Objects[itemNumber].GetComponent<Rigidbody>().isKinematic = false;
                Objects[itemNumber] = null;
                InventorySlots[itemNumber].GetComponent<Image>().sprite = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && !itemActive && Objects[2] != null)
        {
            itemActive = true;
            itemNumber = 2;
            Vector3 newDirection = new Vector3(campos.transform.position.x, campos.transform.position.y, campos.transform.position.z);
            itemcloned = Instantiate(crowbar.gameObject, newDirection, Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90));
            itemcloned.transform.localScale = new Vector3(itemcloned.transform.localScale.x * 8, itemcloned.transform.localScale.y * 8, itemcloned.transform.localScale.z * 8) / 2;
            itemcloned.gameObject.transform.parent = ItemHandler.transform;
            itemcloned.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && itemActive)
        {
            itemActive = false;
            itemNumber = 7;
            Destroy(itemcloned);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Destroy(itemcloned);
            itemActive = false;
            Objects[itemNumber].SetActive(true);
            Objects[itemNumber].transform.position = new Vector3(transform.position.x, transform.position.y - 2.5f, transform.position.z);
            Objects[itemNumber].GetComponent<Rigidbody>().isKinematic = false;
            Objects[itemNumber] = null;
            InventorySlots[itemNumber].GetComponent<Image>().sprite = null;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && !itemActive && Objects[3] != null)
        {
            itemActive = true;
            itemNumber = 3;
            Vector3 newDirection = new Vector3(campos.transform.position.x, campos.transform.position.y, campos.transform.position.z);
            itemcloned = Instantiate(crowbar.gameObject, newDirection, Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90));
            itemcloned.transform.localScale = new Vector3(itemcloned.transform.localScale.x * 8, itemcloned.transform.localScale.y * 8, itemcloned.transform.localScale.z * 8) / 2;
            itemcloned.gameObject.transform.parent = ItemHandler.transform;
            itemcloned.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && itemActive)
        {
            itemActive = false;
            itemNumber = 7;
            Destroy(itemcloned);
        }
        else if (itemActive == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Destroy(itemcloned);
                itemActive = false;
                Objects[itemNumber].SetActive(true);
                Objects[itemNumber].transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
                Objects[itemNumber].GetComponent<Rigidbody>().isKinematic = false;
                Objects[itemNumber] = null;
                InventorySlots[itemNumber].GetComponent<Image>().sprite = null;
            }
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
