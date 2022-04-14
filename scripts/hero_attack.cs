using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero_attack : MonoBehaviour
{
    public Transform attackPoint; // точка атаки
    public LayerMask enemies;

    public int attackDamage = 30;
    public float attackRange = 0.5f;

    public float attackspeed = 2f;
    float nextAttackTime = 0f;

    private void OnDrawGizmosSelected() // функция поможет нагляднее увидеть радиус атаки 
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Attack()
    {
        // анимация атаки
        Collider2D[] hitEnemies =Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemies); // обнаруживает в радиусе атаки противников и запоминает этих чертил

        foreach(Collider2D enemy in hitEnemies) 
        {
            Debug.Log("Атака" + enemy.name);

            enemy.GetComponent<enemy>().TakeDamage(attackDamage);
        }
    }

    private void Update()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetMouseButton(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackspeed;
            }
        }
    }
}
