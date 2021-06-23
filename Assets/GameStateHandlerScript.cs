using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandlerScript : MonoBehaviour
{
    private GameController gameController;
    private ButtonController buttonController;
    private CeilScript boxCeil;

    private double lastObjectElapsedTime = 0.0;
    private double collidingElapsedTime = 0.0;
    private double waitTime = 2.0;

    private void Start() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        buttonController = GameObject.Find("ButtonController").GetComponent<ButtonController>();
        boxCeil = GameObject.Find("Box/Ceil").GetComponent<CeilScript>();
    }

    void Update()
    {
        if (boxCeil.IsColliding) {
            lastObjectElapsedTime = 0;
            collidingElapsedTime += Time.deltaTime;
        } else if (buttonController.isFinished()) {
            lastObjectElapsedTime += Time.deltaTime;
            collidingElapsedTime = 0;
        } else {
            lastObjectElapsedTime = 0;
            collidingElapsedTime = 0;
        }

        if (gameController.State == GameState.Playing) {
            // Failure 判定
            if (isFailed()) {
                gameController.CallGameOver();
            }

            // Clear 判定
            if (isClear()) {
                gameController.CallGameClear();
            }
        }
    }

    private bool isFailed() {
        return collidingElapsedTime > waitTime;
    }

    private bool isClear() {
        return buttonController.isFinished() && lastObjectElapsedTime > waitTime;
    }
}
