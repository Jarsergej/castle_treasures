using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int maxHealth = 80;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // анимация ранения 
        if (currentHealth <= 0)
        {
            Die();
        } 
    }

    void Die()
    {
        Debug.Log("Враг умер");


        this.enabled = false; // "убиваем" врага 
        GetComponent<Collider2D>().enabled = false; // отключаем его хитбокс
    }
}
