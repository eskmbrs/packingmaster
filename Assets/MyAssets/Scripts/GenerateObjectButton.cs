using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonPairs
{
    private ButtonPair[] buttonPairList = new ButtonPair[]
    {
        new ButtonPair("AlarmClock_01", "CoffeeTable_01", "DeskLamp_01", 1, 1, 1),
        new ButtonPair("AlarmClock_01", "CoffeeTable_01", "TeddyBear_01", 1, 1, 1),
        new ButtonPair("AlarmClock_01", "DeskLamp_01", "TeddyBear_01", 1, 1, 1),
        new ButtonPair("AlarmClock_01", "DeskLamp_01", "TeddyBear_01", 2, 1, 1),
        new ButtonPair("AlarmClock_01", "DeskLamp_01", "TeddyBear_01", 1, 2, 1),
        new ButtonPair("AlarmClock_01", "DeskLamp_01", "TeddyBear_01", 1, 1, 2),
        new ButtonPair("AlarmClock_01", "DeskLamp_01", "TeddyBear_01", 2, 1, 2),
        new ButtonPair("CoffeeTable_01", "DeskLamp_01", "TeddyBear_01", 1, 1, 1),
    };

    public ButtonInfo[] generate()
    {
        return buttonPairList[UnityEngine.Random.Range(0, buttonPairList.Length)].GetButtons();
    }
}

public class ButtonPair
{
	private ButtonInfo[] pair;

    public ButtonPair(
        string button1Name,
        string button2Name,
        string button3Name,
        int button1Num,
        int button2Num,
        int button3Num
    )
    {
		var button1 = new ButtonInfo(button1Name, button1Num);
		var button2 = new ButtonInfo(button2Name, button2Num);
		var button3 = new ButtonInfo(button3Name, button3Num);
		this.pair = new ButtonInfo[] { button1, button2, button3 };
	}

    public ButtonInfo[] GetButtons() {
        return pair.OrderBy(i => System.Guid.NewGuid()).ToArray();
    }
}

public class ButtonInfo
{
	public string ObjName;
	public int LastNum;

    public ButtonInfo(string objName, int lastNum)
    {
		ObjName = objName;
		LastNum = lastNum;
	}
}

public class GenerateObjectButton : MonoBehaviour
{
    [SerializeField]
    public int lastNum = 3;

    [SerializeField]
    public string objName;



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
		var pos = this.transform.position;
		var rot = objOnButton.transform.rotation;
		var obj = Instantiate(objOnButton, pos, rot, this.transform);
        obj.transform.localPosition = new Vector3(obj.transform.localPosition.x,-16,obj.transform.localPosition.z);
    }

    public void GenerateObject()
    {
        if (!btn.interactable) return;

        DecrementNumber();

        GameObject obj = (GameObject)Resources.Load(objName);
		var pos = new Vector3(-2f, 3.8f, 0.0f);
		var rot = obj.transform.rotation;
		Instantiate(obj, pos, rot);

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

