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
            GameObject obj = (GameObject)Resources.Load("MyObject");
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(-2f, 2.6f, 0.0f), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject obj = (GameObject)Resources.Load("MySphere");
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(-2f, 2.6f, 0.0f), Quaternion.identity);
        }

    }

}
