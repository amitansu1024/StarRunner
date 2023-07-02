using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _enemySpaceship;
    [SerializeField] private int _numberOfShips; 
    void Start()
    {
        _numberOfShips = 5;

        for (int i = 0; i < _numberOfShips; i++) {
            if (!Physics.CheckSphere(transform.position, 5.0f))
                Instantiate(_enemySpaceship, Random.insideUnitSphere * 200.0f, Quaternion.identity);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
