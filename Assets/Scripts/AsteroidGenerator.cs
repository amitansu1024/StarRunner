using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    
    [SerializeField] private GameObject[] _asteroids = new GameObject[3];
    [SerializeField] private int _numberOfLargeAsteroids;
    [SerializeField] private int _numberOfSmallAsteroids;
    private int _spawnRadius = 200;
    private int _spawnCollisionRadius = 30;
    private GameObject[] _createdAsteroids;

    private void Awake() {
        _numberOfLargeAsteroids = 10;
        _numberOfSmallAsteroids = 50;
        _createdAsteroids = new GameObject[_numberOfLargeAsteroids];
        createAsteroids();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createAsteroids() {
        // large asteroids

        for (int i = 0; i < _numberOfLargeAsteroids; i++) {

            Vector3 position = transform.position + Random.insideUnitSphere * _spawnRadius;
            if (!Physics.CheckSphere(position, _spawnCollisionRadius)) {

                int rand = Random.Range(0, 2);
                GameObject asteroid = Instantiate(_asteroids[rand], position, Random.rotation);
                rand = Random.Range(10, 40);
                asteroid.transform.localScale = new Vector3(rand, rand, rand);
            }
        }
        for (int i = 0; i < _numberOfSmallAsteroids; i++){


            Vector3 position = transform.position + Random.insideUnitSphere * _spawnRadius;
            if (!Physics.CheckSphere(position, _spawnCollisionRadius)) {

                int rand = Random.Range(0, 2);
                GameObject asteroid = Instantiate(_asteroids[rand], position, Random.rotation);
                rand = Random.Range(5, 10);
                asteroid.transform.localScale = new Vector3(rand, rand, rand);
            }

        }

    }

}
