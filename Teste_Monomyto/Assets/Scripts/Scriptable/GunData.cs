using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "GunData", menuName = "Monomyto_Scriptables/GunData", order = 0)]
public class GunData : ScriptableObject {
    [SerializeField] string gunName;
    [SerializeField] Sprite sprite;
    [SerializeField] GameObject bullet;
    [SerializeField] float speed;
    [SerializeField] float rateOfFire;
    [SerializeField] int cartridgeAmount;
    [SerializeField] int maxAmmo;
    [SerializeField] float spawnRate;

    public string GunName { get { return gunName; } }
    public GameObject Bullet { get { return bullet; } }
    public float Speed { get { return speed; } }
    public float RateOfFire { get { return rateOfFire; } }
    public int CartridgeAmount { get { return cartridgeAmount; } }
    public int MaxAmmo { get { return maxAmmo; } }
    public float SpawnRate { get { return spawnRate; } }

    public Sprite Sprite { get { return sprite; } }
}