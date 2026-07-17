
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Door_Trigger : UdonSharpBehaviour
{
    public bool isToch = false;

    public override void Interact()
    {
        if (!isToch)
        {
            isToch = true;
            Debug.Log("クリックされた");
        }
        else
        {
            isToch = false;
            Debug.Log("くっりっくされた");
        }
    }

}