using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : UdonSharpBehaviour
{
    public Image blackImage;

    public float fadeTime = 3f;

    private float timer;

    void Update()
    {
        if (timer < fadeTime)
        {
            timer += Time.deltaTime;

            Color c = blackImage.color;

            c.a = 1f - timer / fadeTime;

            blackImage.color = c;
        }
    }
}