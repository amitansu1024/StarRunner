using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLiveHandler : MonoBehaviour
{
    [SerializeField] private int _lives;
    // Start is called before the first frame update
    void Start()
    {
        _lives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (_lives == 0) {
            Debug.Log("gameover");
        }
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Laser") {
            Debug.Log("Lives lost");
            _lives--;
        }
    }
}
