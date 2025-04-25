using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{   
    public GameObject Camera;
    
    public Text ObjectName;
    public Text ObjectDescription;
    public Text ObjectPickupable;
    public Text ObjectPrice;
    public GameObject ObjectBox;

    public GameObject orientation;  

    public Inventory Inventory;

    public GameObject ToggleButton;

    private Vector3 LocalScale;

    void Start()
    {
        ObjectName.enabled = false;
        ObjectDescription.enabled = false;
        ObjectPickupable.enabled = false;
        ObjectPrice.enabled = false;
        ObjectBox.SetActive(false);

        ToggleButton.SetActive(false);

        LocalScale = new Vector3(ObjectBox.transform.localScale.x, ObjectBox.transform.localScale.y, ObjectBox.transform.localScale.z);
    }

    void Update()
    {

        Debug.DrawRay(Camera.transform.position, Camera.transform.forward * 15, Color.red);

        RaycastHit ObjectDetected;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out ObjectDetected, 15f, LayerMask.GetMask("Object")))
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if (Inventory.AddtoInventory(ObjectDetected.collider.gameObject))
                {
                    ObjectDetected.collider.gameObject.SetActive(false);                
                }
            }

            ObjectName.enabled = true;
            ObjectName.fontSize = 15;
            ObjectDescription.enabled = true;
            ObjectPickupable.enabled = true;
            ObjectBox.SetActive(true);
            ObjectBox.transform.localScale = LocalScale;
            ObjectPrice.enabled = true;
            ObjectName.text = "Object: " + ObjectDetected.collider.GetComponent<IInteractable>().itemName;
            ObjectDescription.text = "Description:                                                                     " + ObjectDetected.collider.GetComponent<IInteractable>().itemDescription;
            ObjectPrice.text = "Price: $" + ObjectDetected.collider.GetComponent<IInteractable>().itemPrice;
        }
        else
        {
            ObjectName.enabled = false;
            ObjectDescription.enabled = false;
            ObjectPickupable.enabled = false;
            ObjectBox.SetActive(false);
            ObjectPrice.enabled = false;    
        }

        RaycastHit ShopDetected;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out ShopDetected, 10f, LayerMask.GetMask("Shop")))
        {
            ToggleButton.SetActive(true);
            ObjectBox.SetActive(true);
            //ObjectBox.transform.localScale = new Vector3(ObjectBox.transform.localScale.x, ObjectBox.transform.localScale.y, ObjectBox.transform.localScale.z);
            ObjectName.enabled = true;
            ObjectName.text = "Open Shop";
            ObjectName.fontSize = 18;

            if (Input.GetKeyDown(KeyCode.X))
            {
                ToggleButton.SetActive(false);
                ObjectBox.SetActive(false);
                ObjectName.enabled = false;
            }

        }
        else
        {
            ToggleButton.SetActive(false);
        }

    }

}
