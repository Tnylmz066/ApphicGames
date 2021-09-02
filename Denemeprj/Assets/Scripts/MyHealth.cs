using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHealth : MonoBehaviour
{
    public float myHealth;
    public hareket hrktscrpt;

    public void TakeDamage(float dmg)
    {
        myHealth -= dmg;

        if (myHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("FAIL");
        hrktscrpt.enabled = false;
    }
}
