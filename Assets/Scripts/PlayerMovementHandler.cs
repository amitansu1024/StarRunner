using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField] private FixedJoystick _movementJoystick;
    [SerializeField] private FixedJoystick _rotationJoystick;
    private float _movementSpeed;
    private float _rotationSpeed;
    private Rigidbody _rigidBody;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody>();
        _movementSpeed = 0.1f;
        _rotationSpeed = 0.7f;
    }


    void FixedUpdate() {
        if (_rigidBody.velocity.magnitude < 10.0f) {
            _rigidBody.velocity += transform.forward * _movementJoystick.Vertical * _movementSpeed;
            _rigidBody.velocity += transform.right * _movementJoystick.Horizontal * _movementSpeed;
        }

        _rigidBody.transform.eulerAngles += 
            new Vector3(- _rotationJoystick.Vertical * _rotationSpeed, _rotationJoystick.Horizontal * _rotationSpeed, 0);
    } 
}
