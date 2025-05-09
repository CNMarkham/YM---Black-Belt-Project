using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    public int Health;
    public int Stamina;

    public int MaxHealth;
    public int MaxStamina;
    
    public GameObject HealthSlider;
    public GameObject StaminaSlider;

    public Text HealthText;
    public Text StaminaText;

    
    void Start()
    {
        Health = 1000;
        Stamina = 1000;

        MaxHealth = 1000;
        MaxStamina = 1000;
    }

    
    void Update()
    {
        HealthSlider.GetComponent<Slider>().value = Health;
        StaminaSlider.GetComponent<Slider>().value = Stamina;

        HealthText.text = Health + "/" + MaxHealth;
        StaminaText.text = Stamina + "/" + MaxStamina;

        if(Health <= 0)
        {
            //SceneManager.LoadScene(1);
        }

    }
}
