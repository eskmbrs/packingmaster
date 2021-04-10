using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoxForward : MonoBehaviour
{
    Rigidbody _rb;

    [SerializeField]
    private float _force = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

            _rb.AddForce(new Vector3(0,0,_force));


    }
}
