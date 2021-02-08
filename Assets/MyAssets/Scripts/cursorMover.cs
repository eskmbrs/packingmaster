using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMover : MonoBehaviour
{

    public Texture2D handCursor;
    // Start is called before the first frame update
    void Start()
    {
        //カーソルを変更（動画用）
        Cursor.SetCursor(handCursor,Vector2.zero,CursorMode.Auto);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
