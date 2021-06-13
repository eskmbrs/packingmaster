using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class GameOverPanel : MonoBehaviour
{
    private GameController gameController;
    private GameObject failedSeal1;
    private GameObject failedSeal2;
    private GameObject failedStamp;
    private GameObject blackHatching;
    private GameObject touchToRestart;
    private bool readyToTouch;
    private bool forTheFirstTime;


    void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        failedSeal1 = GameObject.Find("Canvas/GameOverPanel/FailedSeal1");
        failedSeal2 = GameObject.Find("Canvas/GameOverPanel/FailedSeal2");
        failedStamp = GameObject.Find("Canvas/GameOverPanel/FailedStamp");
        blackHatching = GameObject.Find("Canvas/GameOverPanel/BlackHatching");
        touchToRestart = GameObject.Find("Canvas/GameOverPanel/TouchToRestart");
        forTheFirstTime = true;
    }

    public void Start() {
        // Initialize the Google Mobile Ads SDK
        MobileAds.Initialize(initStatus => { });
    }

    void Update() {
        if (readyToTouch & Input.GetMouseButton(0)) {
            //gameController.CallGameRestart();
            SceneManager.LoadScene("GameScene");
        }
    }

    void OnEnable() {
        readyToTouch = false;
        failedSeal1.gameObject.SetActive(false);
        failedSeal2.gameObject.SetActive(false);
        failedStamp.gameObject.SetActive(false);
        blackHatching.gameObject.SetActive(false);
        touchToRestart.gameObject.SetActive(false);

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
        yield return new WaitForSeconds(0.3f);
        failedSeal1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        failedSeal2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        failedStamp.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        blackHatching.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        touchToRestart.gameObject.SetActive(true);
        readyToTouch = true;
        yield break;
    }
}
