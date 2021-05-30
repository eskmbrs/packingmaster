using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearPanel : MonoBehaviour
{
    private GameController gameController;
    private bool forTheFirstTime;


    void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        forTheFirstTime = true;
    }

    void Update() {
    }

    void OnEnable() {
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
        yield break;
    }

    void blowConfetti() {
        GameObject leftParticle = (GameObject)Resources.Load("LeftParticle");
        GameObject rightParticle = (GameObject)Resources.Load("RightParticle");
        Instantiate(leftParticle);
        Instantiate(rightParticle);
    }
}
