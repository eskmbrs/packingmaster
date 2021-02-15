using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MyButton : MonoBehaviour
{
    private int count;

    [SerializeField]
    string objName;

    // Start is called before the first frame update
    void Start()
    {
        //個数制限
        count = 3;
        UpdateLastNumber();
    }

    public void GenerateObject(string objName)
    {
        GameObject obj = (GameObject)Resources.Load(objName);

        Instantiate(obj, new Vector3(-2f, 3.8f, 0.0f), new Quaternion(0, 90, 0, 0));

        obj.GetComponent<HandController>().controlled = true;
    }

    public void DecrementNumber()
    {
        count--;
        UpdateLastNumber();      
    }

    //パッキングするごとに，数が減っていく
    void UpdateLastNumber()
    {
        GameObject numberText = transform.Find("number").gameObject;
        numberText.GetComponent<TextMeshProUGUI>().text = count.ToString();

    }

}

