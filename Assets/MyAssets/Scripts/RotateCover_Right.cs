﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCover_Right : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;

        if (myTransform.eulerAngles.z >= 270)
        {
            return;
        }

        myTransform.Rotate(0, 0, 5f);
    
    }



}
