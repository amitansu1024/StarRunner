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

    private void Awake() {
        _laserSpeed = 5.0f;
        _aware = false;
        _awareDistance = 30.0f;
        _minimumDistanceFromPlayerShip = 15.0f;
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

        if (_aware && _timer > 2.0f)
        {
            Shoot();
            _timer = 0.0f;
        }

    } 

    void Shoot() {
            GameObject projectile = Instantiate(_laser, transform.position + new Vector3(0.15f, -0.5f, 1.0f), _laser.transform.rotation);
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
            // agent.destination = _playerShip.transform.position;
            // transform.position = Vector3.MoveTowards(transform.position, 
            //                                         _playerShip.transform.position,
            //                                         _enemySpeed * Time.deltaTime);
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
