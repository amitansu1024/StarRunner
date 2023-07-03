using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLiveHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _livesText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _lives;
    [SerializeField] private int _scores;
    void Start()
    {
        _lives = 5;
        _scores = 0;
    }

    void Update()
    {
        if (_lives == 0) {
            MenuHandler.Instance.GameOver();
        }
        else if (_scores == 5) 
            MenuHandler.Instance.GameOver();
            DialogueManager.Instance.YouWinDialogue();
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Asteroid") {
            _livesText.SetText("Lives : " + --_lives);
        }
        else if (collider.gameObject.tag == "Score") 
            _scoreText.SetText("Score : " + --_scores);
    }
}
