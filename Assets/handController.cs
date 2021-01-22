using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handController : MonoBehaviour
{
    private Rigidbody rBody;
    
    [SerializeField]
    public bool controlled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < 2 )
        {
            return;
        }

        // 左に移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(0.1f, 0.0f, 0.0f);
        }
        // 右に移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(-0.1f, 0.0f, 0.0f);
        }
      
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rBody = this.GetComponent<Rigidbody>();
            rBody.useGravity = true;

            controlled = false;
        }
  

    }
}
