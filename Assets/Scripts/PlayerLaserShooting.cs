using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLaserShooting : MonoBehaviour
{
    [SerializeField] private GameObject _laser;
    [SerializeField]float _laserSpeed;
    [SerializeField] private GameObject _shootButton;
    private Rigidbody _laserRigidbody;

    private void Awake() {
        _laserSpeed = 50.0f;

        _shootButton.GetComponent<Button>().onClick.AddListener(Shoot);
    }


    void Shoot() {
        GameObject projectile = Instantiate(_laser, transform.position + new Vector3(-0.3f, 0, 2.0f), _laser.transform.rotation);
        projectile.transform.rotation = transform.rotation;
        projectile.GetComponent<Rigidbody>().velocity = (transform.forward * _laserSpeed);
        Destroy(projectile, 5);
    }
}
