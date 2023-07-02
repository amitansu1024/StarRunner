using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviourHandler : MonoBehaviour
{
    [SerializeField] private GameObject _playerShip;
    [SerializeField] private GameObject _laser;
    [SerializeField] private float _laserSpeed;
    [SerializeField] private float _awareDistance;
    [SerializeField] private float _minimumDistanceFromPlayerShip;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private bool _aware;
    private float _timer;
    private Rigidbody _rigidBody;
    private RaycastHit _raycast;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody>();
        _playerShip = GameObject.Find("Main Camera");
        _laserSpeed = 5.0f;
        _aware = false;
        _awareDistance = 40.0f;
        _minimumDistanceFromPlayerShip = 10.0f;
        _enemySpeed = 3.0f;
    }
    void FixedUpdate() {
        // when the player ship is near be aware
        _timer += Time.deltaTime;

        if (Vector3.Distance(_playerShip.transform.position, transform.position) < _awareDistance)  {
            _aware = true;
        }

        if (_aware) {
            Chase();
        }

        if (_aware && Vector3.Distance(_playerShip.transform.position, transform.position) < 50.0f && _timer > 3.0f)
        {
            Shoot();
            _timer = 0.0f;
        }

        if (Physics.Raycast(transform.position, transform.forward, out _raycast, 15)) {
            if (_raycast.collider.gameObject.CompareTag("Asteroid")) {
                Debug.Log("Asteroid Detected");
                _rigidBody.velocity = transform.right * 5.0f;
            }
        }

    } 

    void Shoot() {
            GameObject projectile = Instantiate(_laser, transform.position + new Vector3(0.15f, -1.5f, 1.0f), _laser.transform.rotation);
            projectile.transform.LookAt(_playerShip.transform);
            Vector3 direction = _playerShip.transform.position - transform.position;
            projectile.GetComponent<Rigidbody>().velocity = (direction * _laserSpeed);
            Destroy(projectile, 5);
            _timer = 0.0f;
    }

    void Chase() {
        LootAtYouAnimation();
        if (Vector3.Distance(_playerShip.transform.position, transform.position) > _minimumDistanceFromPlayerShip) {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            transform.position = Vector3.MoveTowards(transform.position, 
                                                    _playerShip.transform.position,
                                                    _enemySpeed * Time.deltaTime);
        } 
        else if (Vector3.Distance(_playerShip.transform.position, transform.position) < _minimumDistanceFromPlayerShip + 2.0f) {
            transform.position = Vector3.MoveTowards(transform.position, 
                                                    _playerShip.transform.position,
                                                    -_enemySpeed * Time.deltaTime);
        }

    }
    void LootAtYouAnimation() {
            Vector3 targetDirection = _playerShip.transform.position - transform.position;
            float singleStep = 1.0f * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
