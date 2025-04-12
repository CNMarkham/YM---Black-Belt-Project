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

    public int ScavHealth;

    public GameObject Camera;

    private bool CrowbarAttack;

    [SerializeField] private Animator animator;


    public void Pickup()
    {

        throw new System.NotImplementedException();
    }


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scavenger = GameObject.FindGameObjectWithTag("Monster").GetComponent<Scavenger>();
        ScavHealth = scavenger.Health;
        Inventory = player.GetComponent<Inventory>();
        animator = GetComponent<Animator>();
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        CrowbarAttack = false;
    }

    IEnumerator CrowbarActive()
    {
        CrowbarAttack = true;
        Debug.Log(CrowbarAttack);
        Debug.Log("Coroutine Running");
        RaycastHit Attack;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out Attack, 5.5f, LayerMask.GetMask("Monster")))
        {
            Debug.Log(CrowbarAttack);
            ScavHealth -= 25;
            Debug.Log(ScavHealth);
            scavenger.ScavHealthSlider.GetComponent<Slider>().value = ScavHealth;
        }

        yield return new WaitForSeconds(1.75f);
        CrowbarAttack = false;
        Debug.Log(CrowbarAttack);
    }

    void Update()
    {
        Debug.Log(CrowbarAttack);
        Debug.DrawRay(transform.transform.position, Camera.transform.forward * 5.5f, Color.red);
        if (Inventory.itemActive)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && CrowbarAttack == false)
            {
                Inventory.itemcloned.GetComponentInChildren<Animator>().SetTrigger("Attack");
                StartCoroutine(CrowbarActive());
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag == "Monster")
    {
        scavenger = GameObject.FindGameObjectWithTag("Monster").GetComponent<Scavenger>();
        scavenger.Health -= 50;
        Debug.Log(scavenger.Health);
        scavenger.ScavengerHealthSlider.GetComponent<Slider>().value = scavenger.Health;
    }
}
}
