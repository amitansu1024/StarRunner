using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLivesHandler : MonoBehaviour
{
    [SerializeField] int _lives;
    private AudioSource _audio; 
    [SerializeField] private GameObject _blastPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _lives = 3;
    }

    void FixedUpdate() {
        if (_lives == 0) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Laser") {
            Debug.Log("Enemy Lives lost");
            _lives--;
        }
    }

    void OnDestroy() {
        _audio.Play(); 
        Instantiate(_blastPrefab, transform.position, Quaternion.identity);
    }
}

