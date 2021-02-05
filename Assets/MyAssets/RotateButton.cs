using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void RotateObject()
    {
        GameObject ball = GameObject.Find("ragbyBall(Clone)");
       var ballBool = ball.GetComponent<handController>().controlled;


        if (ballBool)
        {
            ball.transform.Rotate(new Vector3(0, 0, 90));
            
        }
 
    }

}
