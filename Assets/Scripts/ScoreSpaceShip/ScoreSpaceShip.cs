using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpaceShip : MonoBehaviour
{
    void Start()
    {
    }

    void FixedUpdate() {
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "MainCamera") {
            DialogueManager.Instance.CollectedDialogue();
            Destroy(this.gameObject);
        }
    }

}

