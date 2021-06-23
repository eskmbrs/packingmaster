using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilScript : MonoBehaviour
{
    public bool IsColliding = false;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Collide!!!!");
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log("Colliding!!!!");
        IsColliding = true;
    }

    private void OnTriggerExit(Collider other) {
        IsColliding = false;
    }
}
