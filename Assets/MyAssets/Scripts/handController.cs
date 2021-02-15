using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
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

    private Vector3 target = new Vector3(-2f, 4.8f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        rBody = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        //爆発のエフェクト
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.GetComponent<Rigidbody>().AddExplosionForce(power, new Vector3(0f, 0f, 0f), radius, upwardsModifier, ForceMode.Impulse);

            //GameObject obj = (GameObject)Resources.Load("ExplosionEffect");
            //GameObject obj = (GameObject)Resources.Load("explosion_stylized_large_originalFireNoSmoke_ShaderGraph");
            GameObject obj = (GameObject)Resources.Load("explosion_stylized_large_originalFire_noSmoke");

            Instantiate(obj, new Vector3(0f, 0f, 0.0f), new Quaternion(0, 0, 0, 0));

        }

          
        //箱の中なら操作を無視（物理エンジンに任せる）
        if (this.transform.position.y < 2 )
        {
            return;
        }

        // 左に移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //this.transform.Translate(-0.1f, 0.0f, 0.0f);
            this.transform.position += new Vector3(-0.1f, 0, 0);
        }
        // 右に移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //this.transform.Translate(0.1f, 0.0f, 0.0f);
            this.transform.position += new Vector3(0.1f, 0, 0);
        }

        //回転させる
        if(controlled)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //transform.Rotate(new Vector3(0, 0, 1), 30);
                transform.RotateAround(target, Vector3.forward, 30);

                // TODO: 回転軸を変更できるようにする
                // TODO: 生成したときの向きを変更できるようにする

            }
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           
            rBody.useGravity = true;

            controlled = false;
        }
  

        

    }

  
}
