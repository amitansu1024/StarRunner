using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    
    [SerializeField] private GameObject[] _asteroids = new GameObject[3];
    [SerializeField] private int _numberOfAsteroids;
    private int _field = 200;
    private GameObject[] _createdAsteroids;

    private void Awake() {
        _numberOfAsteroids = 10;
        _createdAsteroids = new GameObject[_numberOfAsteroids];
        createAsteroids();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createAsteroids() {
        for (int i = 0; i < _numberOfAsteroids; i++) {
            int separationSize = 200 / _numberOfAsteroids;
            int x = Random.Range(-_field, _field);
            int y = Random.Range(-_field + 2 * i * separationSize, -(_field - separationSize) + 2 * i * separationSize);
            int z = Random.Range(-_field, _field);

            Vector3 position = new Vector3(x, y, z);
            GeneratorRandomAsteroid(position);
        }

    }

    GameObject GeneratorRandomAsteroid(Vector3 position) {
        int rand = Random.Range(0, 2);
        GameObject asteroid = Instantiate(_asteroids[rand], position, Quaternion.identity);

        rand = Random.Range(6, 50);
        asteroid.transform.localScale = new Vector3(rand, rand, rand);
        return asteroid;
    }
}
