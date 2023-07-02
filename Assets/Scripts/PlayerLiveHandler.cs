using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLiveHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _livesText;
    [SerializeField] private int _lives;
    void Start()
    {
        _lives = 5;
    }

    void Update()
    {
        if (_lives == 0) {
            MenuHandler.Instance.GameOver();
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Laser") {
            _livesText.SetText("Lives : " + --_lives);
        }
    }
}
