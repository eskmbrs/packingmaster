using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateButton : MonoBehaviour
{
    public bool IsRotating = false;
    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    public void StartToRotate()
    {
        IsRotating = true;
        Debug.Log("isrotating");
    }

    public void StopRotating()
    {
        IsRotating = false;
        Debug.Log("away");
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
