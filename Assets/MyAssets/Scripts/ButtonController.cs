using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonController : MonoBehaviour
{
    public GenerateObjectButton generateObjectButton1;
    public GenerateObjectButton generateObjectButton2;
    public GenerateObjectButton generateObjectButton3;

    public RotateButton rotateButton;
    public MoveButton moveButton;

    void Start()
    {
        generateObjectButton1 = GameObject.Find("Canvas/GenerateObjectButton1").GetComponent<GenerateObjectButton>();
        generateObjectButton2 = GameObject.Find("Canvas/GenerateObjectButton2").GetComponent<GenerateObjectButton>();
        generateObjectButton3 = GameObject.Find("Canvas/GenerateObjectButton3").GetComponent<GenerateObjectButton>();
        rotateButton = GameObject.Find("Canvas/RotateButton").GetComponent<RotateButton>();
        moveButton = GameObject.Find("Canvas/MoveButton").GetComponent<MoveButton>();

        GenerateMode();
    }

    public void GenerateMode()
    {
        if (!moveButton.btn.interactable) return;

        generateObjectButton1.Activate();
        generateObjectButton2.Activate();
        generateObjectButton3.Activate();
        rotateButton.Deactivate();
        moveButton.Deactivate();
    }

    public void RotateMode()
    {
        if (
            rotateButton.btn.interactable
            || moveButton.btn.interactable
        ) return;

        generateObjectButton1.Deactivate();
        generateObjectButton2.Deactivate();
        generateObjectButton3.Deactivate();
        rotateButton.Activate();
        moveButton.Deactivate();
    }

    public void MoveMode()
    {
        if (!rotateButton.btn.interactable) return;

        generateObjectButton1.Deactivate();
        generateObjectButton2.Deactivate();
        generateObjectButton3.Deactivate();
        rotateButton.Deactivate();
        moveButton.Activate();
    }

    public bool isFinished() {
        return !generateObjectButton1.btn.interactable
            && !generateObjectButton2.btn.interactable
            && !generateObjectButton3.btn.interactable
            && !rotateButton.btn.interactable
            && !moveButton.btn.interactable;
    }
}
