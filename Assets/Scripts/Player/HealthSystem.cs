using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 5;
    public static int currentHealth;

    private Healthbar _healthBarScript;

    void Start()
    {
        currentHealth = maxHealth;
        _healthBarScript = GameObject.Find("Healthbar").GetComponent<Healthbar>();
        _healthBarScript.SetMaxHealth(maxHealth);
    }

    

    void Update()
    {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void HurtPlayer(int damageToGiveParam)
    {
        currentHealth -= damageToGiveParam;
        _healthBarScript.SetHealth(currentHealth);
        PlayerPrefs.SetInt("PlayerCurrentHealth", currentHealth);       
    }
}
