using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    [SerializeField] GunCollectable[] Items;

    void Start () {
        GetComponent<Health> ().BeforeDie.AddListener (SpawnItem);
    }

    void SpawnItem () {
        var itemToSpawn = GetRandomItem ();
        if (itemToSpawn != null) {
            Instantiate (itemToSpawn, transform.position, Quaternion.identity);
        }
    }

    GunCollectable GetRandomItem () {
        var rdn = Random.Range (0, 100);
        var curValue = 0f;

        for (int i = 0; i < Items.Length; i++) {
            curValue += Items[i].GetGunData ().SpawnRate;

            if (rdn < curValue)
                return Items[i];
        }
        
        return null;
    }
}