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
    public GameObject ObjectBox;

    public Inventory Inventory;
    


    void Start()
    {
        ObjectName.enabled = false;
        ObjectDescription.enabled = false;
        ObjectPickupable.enabled = false;
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
                    ObjectDetected.collider.gameObject.SetActive(false);
                }
            
                

            }

            ObjectName.enabled = true;
            ObjectDescription.enabled = true;
            ObjectPickupable.enabled = true;
            ObjectBox.SetActive(true);
            ObjectName.text = "Object: " + ObjectDetected.collider.GetComponent<IInteractable>().itemName;
            ObjectDescription.text = "Description:                                                                     " + ObjectDetected.collider.GetComponent<IInteractable>().itemDescription;
        }
        else
        {
            ObjectName.enabled = false;
            ObjectDescription.enabled = false;
            ObjectPickupable.enabled = false;
            ObjectBox.SetActive(false);
        }

    }

}
