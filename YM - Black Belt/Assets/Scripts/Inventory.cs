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
        if (Input.GetKeyDown(KeyCode.Alpha1) && !itemActive)
        {
            itemActive = true;
            Vector3 newDirection = new Vector3(campos.transform.position.x, campos.transform.position.y, campos.transform.position.z);
            itemcloned = Instantiate(crowbar.gameObject, newDirection, Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90));
            itemcloned.transform.localScale = new Vector3(itemcloned.transform.localScale.x*8, itemcloned.transform.localScale.y*8, itemcloned.transform.localScale.z*8) / 2;
            itemcloned.gameObject.transform.parent = ItemHandler.transform;
            itemcloned.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90);


            //itemcloned = Objects[0].gameObject;
            //itemcloned.SetActive(true);
            //itemcloned.transform.position = new Vector3(campos.transform.position.x, campos.transform.position.y, campos.transform.position.z);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1) && itemActive)
        {
            itemActive = false;
            Destroy(itemcloned);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !itemActive)
        {
            itemActive = true;
            Vector3 newDirection = new Vector3(campos.transform.position.x, campos.transform.position.y, campos.transform.position.z);
            itemcloned = Instantiate(crowbar.gameObject, newDirection, Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90));
            itemcloned.transform.localScale = new Vector3(itemcloned.transform.localScale.x * 8, itemcloned.transform.localScale.y * 8, itemcloned.transform.localScale.z * 8) / 2;
            itemcloned.gameObject.transform.parent = ItemHandler.transform;
            itemcloned.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90);

            //itemcloned = Objects[1].gameObject;
            //itemcloned.SetActive(true);
            //itemcloned.transform.position = new Vector3(campos.transform.position.x, campos.transform.position.y, campos.transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && itemActive)
        {
            itemActive = false;
            Destroy(itemcloned);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && !itemActive)
        {
            itemActive = true;
            Vector3 newDirection = new Vector3(campos.transform.position.x, campos.transform.position.y, campos.transform.position.z);
            itemcloned = Instantiate(crowbar.gameObject, newDirection, Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90));
            itemcloned.transform.localScale = new Vector3(itemcloned.transform.localScale.x * 8, itemcloned.transform.localScale.y * 8, itemcloned.transform.localScale.z * 8) / 2;
            itemcloned.gameObject.transform.parent = ItemHandler.transform;
            itemcloned.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90);

            //itemcloned = Objects[2].gameObject;
            //itemcloned.SetActive(true);
            //itemcloned.transform.position = new Vector3(campos.transform.position.x, campos.transform.position.y, campos.transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && itemActive)
        {
            itemActive = false;
            Destroy(itemcloned);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && !itemActive)
        {
            itemActive = true;
            Vector3 newDirection = new Vector3(campos.transform.position.x, campos.transform.position.y, campos.transform.position.z);
            itemcloned = Instantiate(crowbar.gameObject, newDirection, Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90));
            itemcloned.transform.localScale = new Vector3(itemcloned.transform.localScale.x * 8, itemcloned.transform.localScale.y * 8, itemcloned.transform.localScale.z * 8) / 2;
            itemcloned.gameObject.transform.parent = ItemHandler.transform;
            itemcloned.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.x, MainCamera.transform.localRotation.y + 180, MainCamera.transform.localRotation.z + 90);


            //itemcloned = Objects[3].gameObject;
            //itemcloned.SetActive(true);
            //itemcloned.transform.position = new Vector3(campos.transform.position.x, campos.transform.position.y, campos.transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && itemActive)
        {
            itemActive = false;
            Destroy(itemcloned);
        }




        if (itemActive)
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
