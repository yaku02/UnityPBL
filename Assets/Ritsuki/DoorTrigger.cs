using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

public class DoorTrigger : UdonSharpBehaviour
{
    public Animator animator;

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        Debug.Log("入った");

        if (player.isLocal)
        {
            animator.Play("Door_anime");
        }
    }
}