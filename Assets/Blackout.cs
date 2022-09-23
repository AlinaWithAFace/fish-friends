using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blackout : MonoBehaviour
{
    public GameObject blackSquare;

    public void StartFade()
    {
        StartCoroutine(FadeBlackoutSquare());
    }

    public void ReverseFade()
    {
        StartCoroutine(FadeBlackoutSquare(false));
    }


    public IEnumerator FadeBlackoutSquare(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        Color objectColor = blackSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (blackSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }

        yield return new WaitForEndOfFrame();
    }
}