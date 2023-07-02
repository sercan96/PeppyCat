
using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    // Sahne geçişleri esnasında animasyon şeklinde kararma ve aydınlanma olacak.

    public Image ImageClr;
    public AnimationCurve curve;
    
    
    IEnumerator FadeIn() // Sahne açıldığında
    {
        EventManager.InvokeOnGameStart();
        
        float t = 1;
        while (t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            ImageClr.color = new Color(0f, 0f, 0f, a); // a = alpha (4.renk)
            yield return 0;
        }
    }
    
    IEnumerator FadeOut() // Başka sahneye geçiş
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            ImageClr.color = new Color(0f, 0f, 0f, a); // a = alpha (4.renk)
            yield return 0;
        }

        StartCoroutine(FadeIn());
    }

    public void FadeTo()
    {
        StartCoroutine(FadeOut());
    }
}
