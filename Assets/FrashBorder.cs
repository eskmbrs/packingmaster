using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrashBorder : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    private float nextTime;

    [SerializeField]
    public float interval = 0.5f;	// 点滅周期

    [SerializeField]
    public float duration = 2.0f;

    private float _time_for_interval = 0;

    private float _time = 0;

    private bool isStartFrash = false;


    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.enabled = false;

        nextTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (isStartFrash)
        {
            _time += Time.deltaTime;
            _time_for_interval += Time.deltaTime;

            if(_time_for_interval > interval)
            {
                _time_for_interval = 0;
                m_SpriteRenderer.enabled = !m_SpriteRenderer.enabled;
            }

            if(_time > duration)
            {
                m_SpriteRenderer.enabled = false;
                isStartFrash = false;
                _time = 0;
            }
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        isStartFrash = true;
    }
}
