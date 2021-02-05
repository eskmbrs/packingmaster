using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    private Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 前に移動
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(-0.1f, 0.0f, 0.0f);
        }
        // 後ろに移動
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0.1f, 0.0f, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rBody = this.GetComponent<Rigidbody>();
            rBody.useGravity = true;
        }
    }
}
