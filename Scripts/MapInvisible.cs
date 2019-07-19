using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInvisible : MonoBehaviour
{
    float timeSpan;
    public SpriteRenderer spr;
    
    // Start is called before the first frame update
    void Start()
    {
        timeSpan = 0;
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSpan += Time.deltaTime;
        if (timeSpan > 3f && timeSpan < 5f)
        {
            StartCoroutine("GGambbap");
        }
        else if(timeSpan > 6f && timeSpan < 8f)
        {
            StartCoroutine("GGambbap");
        }
        else if (timeSpan > 9f && timeSpan < 11f)
        {
            StartCoroutine("GGambbap");
        }

    }
           
    
    IEnumerator GGambbap()
    {
        Color color = spr.color;
        color.a = 0f;
        spr.color = color;
        yield return new WaitForSeconds(1f);
        color = spr.color;
        color.a = 100f;
        spr.color = color;
    }
}
