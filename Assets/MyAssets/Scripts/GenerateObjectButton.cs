using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonPairs
{
    private ButtonPair[] buttonPairList = new ButtonPair[]
    {
        new ButtonPair("TeddyBear_01","CoffeeTable_01", "DeskLamp_01",1,1,1)
    };

    public ButtonPair generate()
    {
        return buttonPairList[Random.Range(0, buttonPairList.Length)];
    }
}

public class ButtonPair
{
    public string button1;
    public string button2;
    public string button3;

    public int button1Num;
    public int button2Num;
    public int button3Num;

    public ButtonPair(string button1,string button2,string button3,int button1Num,int button2Num,int button3Num)
    {
        this.button1 = button1;
        this.button2 = button2;
        this.button3 = button3;
        this.button1Num = button1Num;
        this.button2Num = button2Num;
        this.button3Num = button3Num;
    }
}

public class GenerateObjectButton : MonoBehaviour
{
    
    [SerializeField]
    public int lastNum = 3;

    [SerializeField]
    public string objName;

    private Vector3 positionToModify = new Vector3(0, -0.36f, 0);

    public Button btn;

    private void Awake()
    {
       btn = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
       UpdateLastNumber();
    }

    public void GenerateObjectOnButton()
    {
        var objOnButton = (GameObject)Resources.Load(objName+"OnButton");
        Instantiate(objOnButton, this.transform.position + positionToModify, Quaternion.identity,this.transform);
        //btnObj.GetComponent<Transform>().transform.localScale = new Vector3(2, 2, 2);
    }

    public void GenerateObject()
    {
        if (!btn.interactable) return;

        DecrementNumber();

        GameObject obj = (GameObject)Resources.Load(objName);

        Instantiate(obj, new Vector3(-2f, 3.8f, 0.0f), Quaternion.Euler(0, 0, 0));

        obj.GetComponent<HandController>().controlled = true;
    }

    private void DecrementNumber()
    {
        lastNum--;
        UpdateLastNumber();
    }

    //パッキングするごとに，数が減っていく
    void UpdateLastNumber()
    {
        GameObject numberText = transform.Find("number").gameObject;
        numberText.GetComponent<TextMeshProUGUI>().text = lastNum.ToString();
    }

    public void Activate()
    {
        if(lastNum > 0)
        {
            btn.interactable = true;
        }
    }

    public void Deactivate()
    {
        btn.interactable = false;
    }

}

