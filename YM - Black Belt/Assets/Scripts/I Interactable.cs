using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string itemName { get; }

    public string itemDescription { get; }

    public int itemPrice { get;  }

    public int itemDamage { get;  }

    public void Pickup();

}
