using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearPanel : MonoBehaviour
{
    private GameController gameController;
    private GameObject boxController;
    private GameObject clearStamp;
    private GameObject blackHatching;
    private GameObject touchToNextGame;
    private bool forTheFirstTime;
    private bool readyToTouch;


    void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        boxController = GameObject.Find("Canvas/GameClearPanel/BoxController");
        clearStamp = GameObject.Find("Canvas/GameClearPanel/GameClear");
        blackHatching = GameObject.Find("Canvas/GameClearPanel/BlackHatching");
        touchToNextGame = GameObject.Find("Canvas/GameClearPanel/TouchToNextGame");
        forTheFirstTime = true;
    }

    void Update() {
        if (readyToTouch & Input.GetMouseButton(0)) {
            //gameController.CallNextGame();
            SceneManager.LoadScene("GameScene_2");
        }
    }

    void OnEnable() {
        boxController.gameObject.SetActive(false);
        clearStamp.gameObject.SetActive(false);
        blackHatching.gameObject.SetActive(false);
        touchToNextGame.gameObject.SetActive(false);

        if (forTheFirstTime) {
            forTheFirstTime = false;
            return;
        };

        StartCoroutine(EnableSequencialy());
    }

    void OnDisable() {
        readyToTouch = false;
    }

    IEnumerator EnableSequencialy()
    {
        blowConfetti();
        yield return new WaitForSeconds(0.3f);
        boxController.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        clearStamp.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        blackHatching.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        touchToNextGame.gameObject.SetActive(true);
        readyToTouch = true;
        yield break;
    }

    void blowConfetti() {
        GameObject leftParticle = (GameObject)Resources.Load("LeftParticle");
        GameObject rightParticle = (GameObject)Resources.Load("RightParticle");
        Instantiate(leftParticle);
        Instantiate(rightParticle);
    }
}
