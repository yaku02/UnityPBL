using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AI_Script : UdonSharpBehaviour
{
    public override void Interact()
    {
        VRCPlayerApi player = Networking.LocalPlayer;

        Vector3 frontPos =
            player.GetPosition()
            + player.GetRotation() * new Vector3(0f, 1.5f, 1.0f);

        transform.position = frontPos;
    }
}