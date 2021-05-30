using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public bool IsRotating = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartToRotate()
    {
        IsRotating = true;
        Debug.Log("isrotating");
    }

    public void StopRotating()
    {
        IsRotating = false;
        Debug.Log("away");
    }


}
