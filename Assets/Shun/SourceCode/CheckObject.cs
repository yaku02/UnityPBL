using UdonSharp;
using UnityEngine;
using VRC.Udon;

public class CheckObject : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject targetObject;

    public override void Interact()
    {
        gameObject.SetActive(false);

    }
}