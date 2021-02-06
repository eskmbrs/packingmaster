using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MyButton : MonoBehaviour
{
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        //個数制限
        count = 3;
        UpdateLabel();
    }

    public void GenerateToyPig()
    {
        GameObject obj = (GameObject)Resources.Load("toypig");
        // Cubeプレハブを元に、インスタンスを生成、
        Instantiate(obj, new Vector3(-2f, 3.8f, 0.0f), new Quaternion(0, 90, 0, 0));

        obj.GetComponent<handController>().controlled = true;
    }
    public void GenerateSoccerBall()
    {
        GameObject obj = (GameObject)Resources.Load("soccerBall");
        // Cubeプレハブを元に、インスタンスを生成、
        Instantiate(obj, new Vector3(-2f, 3.8f, 0.0f), new Quaternion(0, 90, 0, 0));

        obj.GetComponent<handController>().controlled = true;
    }
    public void GenerateToyPenguin()
    {
        GameObject obj = (GameObject)Resources.Load("toypenguin");
        // Cubeプレハブを元に、インスタンスを生成、
        Instantiate(obj, new Vector3(-2f, 3.8f, 0.0f), new Quaternion(0, 270, 0, 0));

        obj.GetComponent<handController>().controlled = true;
    }

    public void DecrementNumber()
    {
        count--;
        UpdateLabel();
    }

    //パッキングするごとに，数が減っていく
    void UpdateLabel()
    {
        GameObject numberText = transform.Find("number").gameObject;
        numberText.GetComponent<TextMeshProUGUI>().text = count.ToString();
    }

}

