using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControllerOnClear : MonoBehaviour
{
    private CloseBox front;

    void Awake()
    {
        front = GameObject.Find("Box/Front").GetComponent<CloseBox>();
    }

    void Update() {
        front.ReduceTransparent();
    }

}
