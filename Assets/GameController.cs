using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;

    private void Awake()
    {
        startPanel = GameObject.Find("Canvas/StartPanel");
        gameOverPanel = GameObject.Find("Canvas/GameOverPanel");
        gameClearPanel = GameObject.Find("Canvas/GameClearPanel");

    }

    // Start is called before the first frame update
    void Start()
    {
        startPanel.gameObject.SetActive(true);
        gameOverPanel.gameObject.SetActive(false);
        gameClearPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {}

    public void CallGameStart()
    {
        StartCoroutine(GameStart());
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
        startPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        gameClearPanel.gameObject.SetActive(false);
        yield break;
  }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
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
}
