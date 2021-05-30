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

    private RotateButton rotateButton;
    private MoveButton moveButton;

    private bool isMoved = false;
    private float insideBox = 2.8f;

    void Start()
    {
        rBody = this.GetComponent<Rigidbody>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        rotateButton = GameObject.Find("Canvas/RotateButton").GetComponent<RotateButton>();
        moveButton = GameObject.Find("Canvas/MoveButton").GetComponent<MoveButton>();
    }

    void Update()
    {

        //爆発のエフェクト
        if (Input.GetKeyDown(KeyCode.A))
        {
            ExplodeObject();
        }

        // Game Clear
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameController.CallGameClear();
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
        gameController.CallGameOver();
        this.GetComponent<Rigidbody>().AddExplosionForce(power, new Vector3(0f, 0f, 0f), radius, upwardsModifier, ForceMode.Impulse);

        GameObject obj = (GameObject)Resources.Load("explosion_stylized_large_originalFire_noSmoke");
        Instantiate(obj, new Vector3(0f, 0f, 0.0f), new Quaternion(0, 0, 0, 0));

    }

    public void DropObject()
    {
        rBody.useGravity = true;
        controlled = false;
    }

}
