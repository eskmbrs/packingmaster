using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearPanel : MonoBehaviour
{
    private GameController gameController;
    private GameObject boxController;
    private GameObject clearStamp;
    private bool forTheFirstTime;


    void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        boxController = GameObject.Find("Canvas/GameClearPanel/BoxController");
        clearStamp = GameObject.Find("Canvas/GameClearPanel/GameClear");
        forTheFirstTime = true;
    }

    void Update() {
    }

    void OnEnable() {
        boxController.gameObject.SetActive(false);
        clearStamp.gameObject.SetActive(false);

        if (forTheFirstTime) {
            forTheFirstTime = false;
            return;
        };

        StartCoroutine(EnableSequencialy());
    }

    void OnDisable() {
    }

    IEnumerator EnableSequencialy()
    {
        blowConfetti();
        yield return new WaitForSeconds(0.3f);
        boxController.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        clearStamp.gameObject.SetActive(true);
        yield break;
    }

    void blowConfetti() {
        GameObject leftParticle = (GameObject)Resources.Load("LeftParticle");
        GameObject rightParticle = (GameObject)Resources.Load("RightParticle");
        Instantiate(leftParticle);
        Instantiate(rightParticle);
    }
}
