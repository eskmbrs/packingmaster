using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handController : MonoBehaviour
{
    private Rigidbody rBody;
    
    [SerializeField]
    public bool controlled;

    [HeaderAttribute("Explosion")]
    [SerializeField, TooltipAttribute("爆発の変数")]
    public float power;
    public float radius;
    [SerializeField, TooltipAttribute("爆発の方向を上に")]
    public float upwardsModifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //爆発のエフェクト
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.GetComponent<Rigidbody>().AddExplosionForce(power, new Vector3(0f, 0f, 0f), radius, upwardsModifier, ForceMode.Impulse);

            GameObject obj = (GameObject)Resources.Load("ExplosionEffect");

            Instantiate(obj, new Vector3(-0.08f, 1.77f, 0.0f), new Quaternion(0, 0, 0, 0));

        }

       
       

        //箱の中なら操作を無視（物理エンジンに任せる）
        if (this.transform.position.y < 2 )
        {
            return;
        }

        // 左に移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-0.1f, 0.0f, 0.0f);
        }
        // 右に移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(0.1f, 0.0f, 0.0f);
        }
      
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rBody = this.GetComponent<Rigidbody>();
            rBody.useGravity = true;

            controlled = false;
        }
  

        

    }

  
}
