using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {
    [SerializeField] int Value = 10;

    GameController gameController;

    void Start () {
        GetComponent<Health> ().BeforeDie.AddListener (AddScore);
        gameController = GameObject.FindObjectOfType<GameController> ();
    }

    void AddScore () {
        gameController.PlayerScore += Value;
    }
}