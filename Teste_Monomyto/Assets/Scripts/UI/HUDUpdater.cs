using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDUpdater : MonoBehaviour {
    TextMeshProUGUI scoreText;

    TextMeshProUGUI gunName;
    Image gunImage;
    TextMeshProUGUI gunAmmo;

    void Start () {
        scoreText = transform.Find ("ScorePanel/Score").GetComponent<TextMeshProUGUI> ();
        gunName = transform.Find ("WeaponPanel/Name").GetComponent<TextMeshProUGUI> ();
        gunImage = transform.Find ("WeaponPanel/Image").GetComponent<Image> ();
        gunAmmo = transform.Find ("WeaponPanel/Ammo").GetComponent<TextMeshProUGUI> ();

        RegisterListeners ();
    }

    void RegisterListeners () {
        var gameController = GameObject.FindObjectOfType<GameController> ();
        if (gameController == null) Debug.LogError ("Game Controller not found. Can't register the score listener.");
        else gameController.ScoreOnChange.AddListener (UpdateScore);

        var gun = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<Gun> ();
        if (gun == null) { Debug.LogError ("Gun not found. Can't register the score listener."); } else {
            gun.GunOnChange.AddListener (UpdateGun);
            gun.AmmoOnChange.AddListener (UpdateAmmo);
        }
    }

    void UpdateScore (int value) {
        scoreText.text = "Score: " + value.ToString ();
    }

    void UpdateGun (GunData gunData) {
        var ammoArr = gunAmmo.text.Split ('/');
        gunAmmo.text = ammoArr[0] + "/" + gunData.MaxAmmo.ToString ();
        gunName.text = gunData.name;
        gunImage.sprite = gunData.Sprite;
    }

    void UpdateAmmo (int curAmmo, int maxAmmo) {
        gunAmmo.text = curAmmo.ToString () + "/" + maxAmmo.ToString ();
    }
}