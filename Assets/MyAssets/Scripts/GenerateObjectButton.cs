using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GenerateObjectButton : MonoBehaviour
{

    [SerializeField]
    private int lastNum = 3;

    [SerializeField]
    string objName;

    [SerializeField]
    private float y_DirectionAtGeneration;

    private Button btn;

    private void Awake()
    {
       btn = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
       UpdateLastNumber();
    }

    public void GenerateObject(string objName)
    {
        GameObject obj = (GameObject)Resources.Load(objName);

        Instantiate(obj, new Vector3(-2f, 3.8f, 0.0f), Quaternion.Euler(0, y_DirectionAtGeneration, 0));

        obj.GetComponent<HandController>().controlled = true;

        DecrementNumber();
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
        btn.interactable = true;
    }

    public void Deactivate()
    {
        btn.interactable = false;
    }

}

