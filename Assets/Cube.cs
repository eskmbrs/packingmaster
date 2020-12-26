using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Cube : MonoBehaviour
{
    //画像リンクから画像をテクスチャにする
    Texture texture;
    //テクスチャをマテリアル化するので生成しておく
    [SerializeField] Material material;
    //画像リンク
    string url = "file:///C:/Users/shinolab/Desktop/onishi/%E3%81%A0%E3%81%84%E3%81%93%E3%81%86%E3%81%95%E3%82%93/%E5%9B%B3/ball.png";
    void Start()
    {
        //先にマテリアルのシェーダを変更しておく
        string shader = "Legacy Shaders/Diffuse";
        material.shader = Shader.Find(shader);
        StartCoroutine(Connect());
    }

    //テクスチャを読み込む
    private IEnumerator Connect()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            //textureに画像が入るよ
            texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            //textureをマテリアルにセット
            material.SetTexture("_MainTex", texture);

            gameObject.GetComponent<Renderer>().material = material;
            
        }
    }
}
