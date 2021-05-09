using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    GameController gameController;

    void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }


    public void OnClick() {
        gameController.CallGameStart();
    }
}
