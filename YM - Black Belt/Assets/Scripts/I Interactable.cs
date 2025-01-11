using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string itemName { get; }

    public string itemDescription { get; }


    public void Pickup();

}
