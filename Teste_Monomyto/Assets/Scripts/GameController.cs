using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour {
    int playerScore;
    public int PlayerScore {
        get { return playerScore; }
        set {
            playerScore = value;
            ScoreOnChange.Invoke (playerScore);
        }
    }
    public UnityEvent_Int ScoreOnChange;
}