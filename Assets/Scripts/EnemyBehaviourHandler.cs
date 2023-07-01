using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourHandler : MonoBehaviour
{
    [SerializeField] private GameObject _playerShip;
    private bool _aware;

    private void Awake() {
        _aware = false;
    }
    void FixedUpdate() {
        // when the player ship is near be aware
        if (Vector3.Distance(_playerShip.transform.position, transform.position) < 10.0f)  {
            Debug.Log("I am aware");
            _aware = true;
        }
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
