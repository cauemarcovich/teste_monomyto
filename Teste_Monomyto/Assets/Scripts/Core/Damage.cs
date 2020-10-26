using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    [SerializeField] float _value = 10f;

    void OnCollisionEnter2D (Collision2D other) {
        var health = other.gameObject.GetComponent<Health> ();
        if (health != null)
            health.DealDamage (_value);
            
        Destroy (gameObject);
    }
}