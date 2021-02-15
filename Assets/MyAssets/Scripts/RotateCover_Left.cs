using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCover_Left : MonoBehaviour
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
            CloseBox_Left();
        }

        
        
    }

    

    void CloseBox_Left()
    {
        // ToDo: 回転スピードを早くすると，カクツク問題を解決する
        
        Transform myTransform = this.transform;

        //if(myTransform <= -270)
        //-240 = 120, -270 = 90というように，角度が正の値に修正されるようになっているので，回転が止まらなかった

        if (0 < myTransform.eulerAngles.z && myTransform.eulerAngles.z <= 90)
        {
            return;
        }

        myTransform.Rotate(0, 0, _rotateVerocity);
    }
}
