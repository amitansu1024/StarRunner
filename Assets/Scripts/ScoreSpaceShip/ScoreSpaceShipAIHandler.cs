using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScoreSpaceShipAIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _playerShip;
    [SerializeField] private GameObject _laser;
    [SerializeField] private float _laserSpeed;
    [SerializeField] private float _awareDistance;
    [SerializeField] private float _minimumDistanceFromPlayerShip;
    [SerializeField] private float shipSpeed;
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
        _minimumDistanceFromPlayerShip = 80.0f;
        shipSpeed = 5.0f;
    }
    void FixedUpdate() {

        // become aware if the player is at a certain distance
        if (Vector3.Distance(_playerShip.transform.position, transform.position) < _awareDistance && !_aware)  {
            _aware = true;
            DialogueManager.Instance.WarnPlayerDialogue();
        }

        // move away from player if spotted
        if (_aware) {
            MoveAway();
        }

        // avoid Asteroid wherever possible
        if (Physics.Raycast(transform.position, -transform.forward, out _raycast, 15)) {
            if (_raycast.collider.gameObject.CompareTag("Asteroid")) {
                _rigidBody.velocity = transform.right * 5.0f;
            }
        }

    } 
    void MoveAway() {
        LootAtYouAnimation();
        if (Vector3.Distance(_playerShip.transform.position, transform.position) < _minimumDistanceFromPlayerShip + 2.0f) {
            transform.position = Vector3.MoveTowards(transform.position, 
                                                    _playerShip.transform.position,
                                                    -shipSpeed * Time.deltaTime);
        }

    }
    void LootAtYouAnimation() {
            Vector3 targetDirection = _playerShip.transform.position - transform.position;
            float singleStep = 1.0f * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
