using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumTape : MonoBehaviour
{
    [SerializeField]
    private float _centerAtMoving=0.1f;
    [SerializeField]
    private float _speedOfGrowth=0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            this.transform.position += new Vector3(0, 0, _centerAtMoving);
            this.transform.localScale += new Vector3(0, 0, _speedOfGrowth);
        }
    }
}
