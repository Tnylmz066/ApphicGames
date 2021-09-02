
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DandikAI : MonoBehaviour
{
    Transform target;
    public float radiusAttack;
    public LayerMask playerMask;

    NavMeshAgent myAgent;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void FixedUpdate()
    {
        bool inRange = Physics.CheckSphere(transform.position, radiusAttack, playerMask);

        if (!inRange) myAgent.SetDestination(target.position);
        else
        {
            Debug.Log("Sana Vuruyom");
            AttackPlayer();
            myAgent.SetDestination(transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, radiusAttack);
        Gizmos.color = Color.red;
    }

    void AttackPlayer() {
        target.gameObject.GetComponent<MyHealth>().TakeDamage(25f);
        Destroy(this.gameObject);
    }
}