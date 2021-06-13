using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    public bool IsMoving = false;
    public Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    public void StartToMove()
    {
        if (!btn.interactable) return;

        IsMoving = true;
        Debug.Log("ismoving");
    }

    public void StopMoving()
    {
        if (!btn.interactable) return;

        IsMoving = false;
        Debug.Log("away_move");
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
