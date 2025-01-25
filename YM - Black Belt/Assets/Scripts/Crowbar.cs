using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : ItemDetails, IInteractable
{
    public string itemName => "Crowbar";

    public string itemDescription => "A hefty weapon that can be used for self-defense.";

    public new Sprite ItemSprite { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }


    public void Pickup()
    {

        throw new System.NotImplementedException();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
