﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //終わりのエフェクト
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameObject.SetActive(false);
        }

    }
}
