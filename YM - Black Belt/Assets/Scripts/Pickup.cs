using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pickup : MonoBehaviour
{
    public GameObject PickupUI;

    void Start()
    {
        PickupUI.SetActive(false);
    }

    void Update()
    {
        //Vector3 Direction = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);

        RaycastHit ObjectDetected;
        if (Physics.Raycast(transform.position, Vector3.forward, out ObjectDetected, 10f, LayerMask.GetMask("Object")))
        {
            PickupUI.SetActive(true);
        }
        else
        {
            PickupUI.SetActive(false);
        }

    }
}
