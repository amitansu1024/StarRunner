using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIAvoidObstacle : MonoBehaviour
{
    private RaycastHit _raycast;
    private Rigidbody _rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
