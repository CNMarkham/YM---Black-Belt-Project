using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crowbar : ItemDetails, IInteractable
{
    public string itemName => "Crowbar";

    public string itemDescription => "A hefty weapon that can be used for self-defense.";


    public new Sprite ItemSprite { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public int itemPrice => 25;

    public int itemDamage => 45;

    public float xOffset => 0.75f;

    public float yOffset => 0.5f;

    public float zOffset => 1.5f;

    private Inventory Inventory;

    public GameObject player;

    public Scavenger scavenger;

    [SerializeField] private Animator animator;
    

    public void Pickup()
    {

        throw new System.NotImplementedException();
    }


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Inventory = player.GetComponent<Inventory>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Inventory.itemActive)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("MouseButtonClciked");
                Inventory.itemcloned.GetComponentInChildren<Animator>().SetTrigger("Attack");
            }
        }   
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            scavenger = GameObject.FindGameObjectWithTag("Monster").GetComponent<Scavenger>();
            scavenger.Health -= 50;
            Debug.Log(scavenger.Health);
            scavenger.ScavengerHealthSlider.GetComponent<Slider>().value = scavenger.Health;
        }
    }
}
