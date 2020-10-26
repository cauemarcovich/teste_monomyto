using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollectable : MonoBehaviour {
    [SerializeField] GunData gunData;
    public GunData GetGunData () { return gunData; }

    void OnTriggerEnter2D (Collider2D other) {
        var playerGun = other.GetComponentInChildren<Gun> ();

        if (playerGun != null) {
            playerGun.ChangeGun (gunData);
            Destroy (gameObject);
        }
    }
}