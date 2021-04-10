using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCover_Right : MonoBehaviour
{
    [SerializeField]
    private float _rotateVerocity = -10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            CloseBox_Right();
        }
    }

    void CloseBox_Right()
    {
        Transform myTransform = this.transform;

        if (myTransform.eulerAngles.z >= 270)
        {
            return;
        }

        myTransform.Rotate(0, 0, _rotateVerocity);
    }

}
