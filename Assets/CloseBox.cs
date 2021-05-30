using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBox : MonoBehaviour
{
    MeshRenderer mr;

    [SerializeField]
    private float _transparentSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            ReduceTransparent();
        }

    }

    public void ReduceTransparent() {
        mr.material.color += new Color(0, 0, 0, _transparentSpeed);
    }

}
