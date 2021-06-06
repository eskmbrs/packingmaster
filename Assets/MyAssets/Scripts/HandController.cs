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
    private GameController gameController;

    public GenerateObjectButton generateObjectButton1;
    public GenerateObjectButton generateObjectButton2;
    public GenerateObjectButton generateObjectButton3;
    private RotateButton rotateButton;
    private MoveButton moveButton;

    private bool isMoved = false;
    
    private float insideBox = 2.8f;
    private float insideBox_top = 0.8f;

    private int clear_count_int = 0;
    private int failure_count_int = 0;

    [SerializeField]
    private bool isLastObject = false;

    private bool forTheFirstTime_explode = true;


    void Start()
    {
        rBody = this.GetComponent<Rigidbody>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        generateObjectButton1 = GameObject.Find("Canvas/GenerateObjectButton1").GetComponent<GenerateObjectButton>();
        generateObjectButton2 = GameObject.Find("Canvas/GenerateObjectButton2").GetComponent<GenerateObjectButton>();
        generateObjectButton3 = GameObject.Find("Canvas/GenerateObjectButton3").GetComponent<GenerateObjectButton>();
        rotateButton = GameObject.Find("Canvas/RotateButton").GetComponent<RotateButton>();
        moveButton = GameObject.Find("Canvas/MoveButton").GetComponent<MoveButton>();

        //　最後のオブジェクトなら，lastObject==true
        if (generateObjectButton1.lastNum == 0 && generateObjectButton2.lastNum == 0 && generateObjectButton3.lastNum == 0)
        {
            isLastObject = true;
        }
    }

    void Update()
    {
        //クリア判定
        //最後のオブジェクトが，ボックス内にある時
        if (isLastObject && transform.position.y < insideBox_top)
        {
            clear_count_int++;
            if (clear_count_int > 50)
            {
                gameController.CallGameClear();
            }
        }

        //Failure判定
        //重力がかかっていて，上にはみ出している時
        if(!controlled && transform.position.y > insideBox_top)
        {
            failure_count_int++;
            if(failure_count_int > 100)
            {
                gameController.CallGameOver();
                if (forTheFirstTime_explode)
                {
                    ExplodeObject();
                    forTheFirstTime_explode = false;
                }
                controlled = true;
                failure_count_int = 0;
            }
        }


        //回転させる
        if(controlled)
        {
            if (rotateButton.IsRotating)
            {
                transform.RotateAround(target, Vector3.forward, -7);

            }

            if (moveButton.IsMoving)
            {
                if (this.transform.position.x < insideBox) {
                    this.transform.position += new Vector3(0.1f, 0, 0);
                }
                isMoved = true;
            }

            if(isMoved && !moveButton.IsMoving)
            {
                DropObject();
            }
        }

    }

    private void ExplodeObject()
    {
        //吹っ飛ぶ力を加える
        this.GetComponent<Rigidbody>().AddExplosionForce(power, new Vector3(0f, 0f, 0f), radius, upwardsModifier, ForceMode.Impulse);
        //爆発のパーティクルエフェクト
        GameObject obj = (GameObject)Resources.Load("explosion_stylized_large_originalFire_noSmoke");
        Instantiate(obj, new Vector3(0f, 0f, 0.0f), new Quaternion(0, 0, 0, 0));
    }

    public void DropObject()
    {
        rBody.useGravity = true;
        controlled = false;
    }

}
