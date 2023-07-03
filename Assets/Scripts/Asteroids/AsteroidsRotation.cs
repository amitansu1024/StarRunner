using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsRotation : MonoBehaviour
{
    private float _rotationSteps;
    // Start is called before the first frame update
    void Start()
    {
        _rotationSteps = 0.15f;
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * _rotationSteps;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
