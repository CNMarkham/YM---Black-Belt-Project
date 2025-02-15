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


    


    void Start()
    {
        ObjectName.enabled = false;
        ObjectDescription.enabled = false;
        ObjectPickupable.enabled = false;
        ObjectPrice.enabled = false;
        ObjectBox.SetActive(false);
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
                    ObjectDetected.transform.localScale = new Vector3(ObjectDetected.transform.localScale.x, ObjectDetected.transform.localScale.y, ObjectDetected.transform.localScale.z) / 2;
                    ObjectDetected.collider.gameObject.SetActive(false);
                    ObjectDetected.collider.gameObject.transform.parent = orientation.transform;
                }



            }

            ObjectName.enabled = true;
            ObjectDescription.enabled = true;
            ObjectPickupable.enabled = true;
            ObjectBox.SetActive(true);
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

    }

}
