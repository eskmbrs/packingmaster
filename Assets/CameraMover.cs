using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraMover : MonoBehaviour
{

    [SerializeField]
    private float _rotateVerocity = 1f;
    [SerializeField]
    private float _moveVerocity = 0.1f;

    void Start()
    {

    }

    void Update()
    {
        CamMoveGoalAction();
    }

    public void CamMoveGoalAction()
    {
        //x軸周りの回転
        if (Input.GetKey(KeyCode.B))
        {
            //90度でストップ
            if(this.transform.eulerAngles.x >= 90)
            {
                return;
            }

            transform.Rotate(_rotateVerocity, 0, 0);
            transform.position += new Vector3(0, _moveVerocity, _moveVerocity);

        }

    }

}
