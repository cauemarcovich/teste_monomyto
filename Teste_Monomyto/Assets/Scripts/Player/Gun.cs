using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour {
    [HideInInspector] public UnityEvent_GunData GunOnChange;
    [HideInInspector] public UnityEvent_Int_Int AmmoOnChange;

    [SerializeField] GunData gun;
    public string GetCurrentGunName () { return gun != null ? gun.GunName : "Unarmed"; }

    int ammo;
    int maxAmmo;

    float lastShootTime;
    bool isInCooldown { get { return Time.time < lastShootTime; } }
    bool isRecharging;

    void Update () {
        if (Input.GetButton ("Fire1") && !isInCooldown && !isRecharging) {
            if (gun != null) {
                if (ammo > 0)
                    Shoot ();
                else if (maxAmmo > 0)
                    StartCoroutine (Recharge ());
            }
        }
    }
    
    void Shoot () {
        lastShootTime = Time.time + gun.RateOfFire;

        var shoot = Instantiate (gun.Bullet, transform.position, transform.rotation);
        shoot.GetComponent<Rigidbody2D> ().velocity = transform.up * gun.Speed;

        ChangeAmmo (ammo - 1, maxAmmo);
    }

    IEnumerator Recharge () {
        isRecharging = true;

        yield return new WaitForSeconds (1f);
        ChangeAmmo (gun.CartridgeAmount, maxAmmo - gun.CartridgeAmount);

        isRecharging = false;
    }

    public void ChangeGun (GunData gunData) {
        if (gunData != gun) {
            gun = gunData;
            GunOnChange.Invoke (gunData);

            ChangeAmmo (gunData.CartridgeAmount, gunData.CartridgeAmount);
        } else {
            ChangeAmmo (ammo, Mathf.Min (maxAmmo + gun.CartridgeAmount, gun.MaxAmmo));
        }
    }

    void ChangeAmmo (int curValue, int maxValue) {
        ammo = curValue;
        maxAmmo = maxValue;
        AmmoOnChange.Invoke (ammo, maxAmmo);
    }
}