using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowLights : MonoBehaviour
{

    public float speed;
    public Color startColor;
    public Color endColor;
    public bool repeatable = false;
    float startTime;

    public Light lt;

    void Start()
    {
        startTime = Time.time;
        StartCoroutine(ColorChange());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ColorChange()
    {
        //Debug.Log("Starting ColorChange!");
        float t = (Time.time - startTime) * speed;
        lt.color = Color.Lerp(startColor, endColor, t);
        //GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
        yield return new WaitForSeconds(3);
        float a = (Mathf.Sign(Time.time - startTime) * speed);
        lt.color = Color.Lerp(endColor, startColor, t);
        //GetComponent<Renderer>().material.color = Color.Lerp(endColor, startColor, t);
        yield return new WaitForSeconds(3);
        StartCoroutine(ColorChange());
    }
}
