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
        // �������� ������� 
        if (currentHealth <= 0)
        {
            Die();
        } 
    }

    void Die()
    {
        Debug.Log("���� ����");


        this.enabled = false; // "�������" ����� 
        GetComponent<Collider2D>().enabled = false; // ��������� ��� �������
    }
}
