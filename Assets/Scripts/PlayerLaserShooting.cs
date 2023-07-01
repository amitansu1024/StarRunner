using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLaserShooting : MonoBehaviour
{
    [SerializeField] private GameObject _laser;
    [SerializeField] private float _laserSpeed;
    [SerializeField] private GameObject _shootButton;
    private Rigidbody _laserRigidbody;

    private void Awake() {
        _laserSpeed = 50.0f;
        _laserRigidbody = _laser.GetComponent<Rigidbody>();

        _shootButton.GetComponent<Button>().onClick.AddListener(Shoot);
    }


    void Shoot() {
        GameObject projectile = Instantiate(_laser, this.transform.position + new Vector3(0, 0, 1.0f), _laser.transform.rotation);


        projectile.GetComponent<Rigidbody>().AddRelativeForce(transform.up * _laserSpeed);
    }
}
