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
        _audio = this.gameObject.GetComponent<AudioSource>();
        _lives = 3;
    }

    void FixedUpdate() {
        if (_lives == 0) {
            GameObject blast = Instantiate(_blastPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(blast, 2);
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
    }
}

