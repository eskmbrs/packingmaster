using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TouchToNextGame : MonoBehaviour
{
  public float speed = 0.6f;

  private TextMeshProUGUI text;
  private float time;


  void Start() {
    time = 0;
    text = this.gameObject.GetComponent<TextMeshProUGUI>();
  }

  void Update () {
    text.color = GetNewColor(text.color);
  }

  // Alpha 値を更新する
  Color GetNewColor(Color color) {
    time += Time.deltaTime * 5.0f * speed;
    color.a = Mathf.Sin(time) * 0.5f + 0.5f;

    return color;
  }
}
