using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;

    [SerializeField]
    private bool isStart = false;

    private void Awake()
    {
        startPanel = GameObject.Find("Canvas/StartPanel");
        gameOverPanel = GameObject.Find("Canvas/GameOverPanel");
        gameClearPanel = GameObject.Find("Canvas/GameClearPanel");
    }

    // Start is called before the first frame update
    void Start()
    {
        // GameSceneが読み込まれた時にスタートパネルを表示させないために
        // 一番最初にこの処理をする
        startPanel.gameObject.SetActive(isStart);

        // Initialize the Google Mobile Ads SDK
        MobileAds.Initialize(initStatus => { });

        if (isStart) {
            gameOverPanel.gameObject.SetActive(false);
            gameClearPanel.gameObject.SetActive(false);
        } else {
            CallGameStart();
        }
    }

    // Update is called once per frame
    void Update()
    {}

    public void CallGameStart()
    {
        StartCoroutine(GameStart());
    }

    public void CallGameRestart()
    {
        StartCoroutine(GameRestart());
    }

    public void CallNextGame()
    {
        StartCoroutine(NextGame());
    }

    public void CallGameOver()
    {
        StartCoroutine(GameOver());
    }

    public void CallGameClear()
    {
        StartCoroutine(GameClear());

    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(0.5f);
        RequestInterstitial();
        startPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        gameClearPanel.gameObject.SetActive(false);
        yield break;
    }

    IEnumerator GameRestart()
    {
        this.interstitial.Destroy();
        yield return new WaitForSeconds(0.5f);
        startPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        gameClearPanel.gameObject.SetActive(false);
        SceneManager.LoadScene("GameScene");
        yield break;
    }

    IEnumerator NextGame()
    {
        yield return new WaitForSeconds(0.5f);
        startPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        gameClearPanel.gameObject.SetActive(false);
        yield break;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        if (this.interstitial.IsLoaded()) {
            this.interstitial.Show();
            yield return new WaitForSeconds(1.0f);
        }

        startPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        gameClearPanel.gameObject.SetActive(false);
        yield break;
    }

    IEnumerator GameClear()
    {
        yield return new WaitForSeconds(0.5f);
        startPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        gameClearPanel.gameObject.SetActive(true);
        yield break;
    }

    private InterstitialAd interstitial;

    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
            string adUnitId = "unexpected_platform";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        this.interstitial.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdClosed(object sender, System.EventArgs args)
    {
        //メモリリーク防止
        interstitial.Destroy();
    }
}
