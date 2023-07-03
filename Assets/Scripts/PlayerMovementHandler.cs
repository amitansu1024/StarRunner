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
    private float _yaw;
    private float _pitch;
    private Rigidbody _rigidBody;

    private void Awake() {
        _yaw = 0.0f;
        _pitch = 0.0f;
        _rigidBody = GetComponent<Rigidbody>();
        _movementSpeed = 0.1f;
        _rotationSpeed = 3.0f;
        _brakesButton.onClick.AddListener(Brakes);
    }


    void FixedUpdate() {
        PlayerMovements();
        CameraMovements();
        Brakes();


        //drag force
        _rigidBody.AddForce(_rigidBody.velocity * -0.1f);
    } 

    void Update() {
    }

    void Brakes() {
        float brakesValue = Input.GetAxis("Fire1");
        if (brakesValue > 0)
            _rigidBody.AddForce(_rigidBody.velocity * -5.0f);
    }

    void PlayerMovements() {
        float horizontalValue = Input.GetAxis("Horizontal");
        float verticalValue = Input.GetAxis("Vertical");

        if (horizontalValue > 0) // move right
            _rigidBody.velocity += transform.right * _movementSpeed;
        if (horizontalValue < 0)  // move left
            _rigidBody.velocity += -transform.right * _movementSpeed;
        if (verticalValue > 0) // move forward
            _rigidBody.velocity += transform.forward * _movementSpeed;
        if (verticalValue < 0)  // move back
            _rigidBody.velocity += -transform.forward * _movementSpeed;
    }


    void CameraMovements() {
        _yaw  += _rotationSpeed * Input.GetAxis("Mouse X");
        _pitch  -= _rotationSpeed * Input.GetAxis("Mouse Y");

        transform.localEulerAngles = new Vector3(_pitch, _yaw, 0.0f);
    }
}
