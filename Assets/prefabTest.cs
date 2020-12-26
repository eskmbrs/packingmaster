using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject obj = (GameObject)Resources.Load("BEAR");
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(-2f,3.8f, 0.0f), new Quaternion(0,90,0,0));
        }
  
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject obj = (GameObject)Resources.Load("Beer");
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(-2f, 3.8f, 0.0f), new Quaternion(0, 180, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject obj = (GameObject)Resources.Load("Ball");
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(-2f, 3.8f, 0.0f), new Quaternion(0, 180, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject obj = (GameObject)Resources.Load("SHEEP");
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(-2f, 3.8f, 0.0f), new Quaternion(0, 180, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject obj = (GameObject)Resources.Load("PIG");
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(-2f, 3.8f, 0.0f), new Quaternion(0, 180, 0, 0));
        }


    }

}
