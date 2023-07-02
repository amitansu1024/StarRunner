using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField] private FixedJoystick _movementJoystick;
    [SerializeField] private FixedJoystick _rotationJoystick;
    [SerializeField] private Button _brakesButton;
    private float _movementSpeed;
    private float _rotationSpeed;
    private Rigidbody _rigidBody;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody>();
        _movementSpeed = 0.1f;
        _rotationSpeed = 0.7f;
        _brakesButton.onClick.AddListener(Brakes);
    }


    void FixedUpdate() {
        // if (_rigidBody.velocity.magnitude < 10.0f) {
            _rigidBody.velocity += transform.forward * _movementJoystick.Vertical * _movementSpeed;
            _rigidBody.velocity += transform.right * _movementJoystick.Horizontal * _movementSpeed;
        // }

        //brakes
        _rigidBody.AddForce(_rigidBody.velocity * -0.1f);

        _rigidBody.transform.eulerAngles += 
            new Vector3(- _rotationJoystick.Vertical * _rotationSpeed, _rotationJoystick.Horizontal * _rotationSpeed, 0);
    } 

    void Brakes() {
        _rigidBody.AddForce(_rigidBody.velocity * -5.0f);
    }
}
