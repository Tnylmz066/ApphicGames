using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Enemy")) {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (col.gameObject.CompareTag("Engel")) {
            Destroy(this.gameObject);
        }
    }
}
