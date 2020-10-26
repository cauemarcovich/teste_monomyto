using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {
    [HideInInspector] public UnityEvent BeforeDie;

    [SerializeField] float health = 100f;

    public void DealDamage (float damage) {
        health -= damage;

        if (health <= 0f)
            Die ();
    }

    public void Die () {
        BeforeDie.Invoke ();
        Destroy (gameObject);
    }
}