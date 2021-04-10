using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearActionScript : MonoBehaviour
{
    GameObject _canvas;

    // Start is called before the first frame update
    void Start()
    {
        _canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            // ToDo: カメラワークを上に移動
            // Completed: カメラオブジェクトにスクリプトをアタッチした

            // ToDo: Canvasの消去
            // Completed:
            _canvas.SetActive(false);

            // ToDo: Deskの出現
            // Completed: 最初から出現させておくことにした．

            // ToDo: ガムテープを貼るアクション

            // ToDo: 紙吹雪
            //爆発のエフェクト
            if (Input.GetKeyDown(KeyCode.B))
            {
                GameObject leftParticle = (GameObject)Resources.Load("LeftParticle");
                GameObject rightParticle = (GameObject)Resources.Load("RightParticle");

                Instantiate(leftParticle);
                Instantiate(rightParticle);





            }
        }
    }
}
