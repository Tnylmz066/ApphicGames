
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;

    public void TakeDamage(float dmg)
    {
        enemyHealth -= dmg;

        if(enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Öldüm");
        Destroy(this.gameObject);
    }
}
