using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float currentHealth;
    public float maxHealth =100f;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = player.currentHealth;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
