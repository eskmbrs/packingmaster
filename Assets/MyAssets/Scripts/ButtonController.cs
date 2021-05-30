using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    generateMode = 0,
    rotateMode = 1,
    movingMode = 2,
}

public class ButtonController : MonoBehaviour
{
    public GenerateObjectButton generateObjectButton1;
    public GenerateObjectButton generateObjectButton2;
    public GenerateObjectButton generateObjectButton3;

    public RotateButton rotateButton;
    public MoveButton moveButton;

    public State state;

    // Start is called before the first frame update
    void Start()
    {
        generateObjectButton1 = GameObject.Find("Canvas/GenerateObjectButton1").GetComponent<GenerateObjectButton>();
        generateObjectButton2 = GameObject.Find("Canvas/GenerateObjectButton2").GetComponent<GenerateObjectButton>();
        generateObjectButton3 = GameObject.Find("Canvas/GenerateObjectButton3").GetComponent<GenerateObjectButton>();
        rotateButton = GameObject.Find("Canvas/RotateButton").GetComponent<RotateButton>();
        moveButton = GameObject.Find("Canvas/MoveButton").GetComponent<MoveButton>();

        GenerateMode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMode()
    {
        state = State.generateMode;

        generateObjectButton1.Activate();
        generateObjectButton2.Activate();
        generateObjectButton3.Activate();
        rotateButton.Deactivate();
        moveButton.Deactivate();

    }

    public void RotateMode()
    {
        state = State.rotateMode;

        generateObjectButton1.Deactivate();
        generateObjectButton2.Deactivate();
        generateObjectButton3.Deactivate();
        rotateButton.Activate();
        moveButton.Deactivate();

        
    }

    public void MoveMode()
    {
        generateObjectButton1.Deactivate();
        generateObjectButton2.Deactivate();
        generateObjectButton3.Deactivate();
        rotateButton.Deactivate();
        moveButton.Activate();

        state = State.movingMode;
    }


}
