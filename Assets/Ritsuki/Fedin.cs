using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class Fedin : UdonSharpBehaviour
{
    public Image image;

    void Start()
    {
        Color c = image.color;
        c.a = 0.5f;
        image.color = c;
    }
}