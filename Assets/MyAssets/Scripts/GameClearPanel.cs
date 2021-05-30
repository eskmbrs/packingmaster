using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearPanel : MonoBehaviour
{
    private GameController gameController;
    private bool forTheFirstTime = true;


    void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Start() {
        forTheFirstTime = false;
    }

    void Update() {
    }

    void OnEnable() {
        if (forTheFirstTime) {return;};

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
