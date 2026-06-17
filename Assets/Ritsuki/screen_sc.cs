using UdonSharp;
using UnityEngine;

public class screen_sc : UdonSharpBehaviour
{

    public GameObject screen;

    public override void Interact()
    {
        screen.SetActive(true);
    }
}