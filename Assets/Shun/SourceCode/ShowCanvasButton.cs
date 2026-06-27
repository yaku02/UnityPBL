using UdonSharp;
using UnityEngine;
using VRC.Udon;

public class ShowCanvasButton : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject targetCanvas;

    public void ShowCanvas()
    {
        if (targetCanvas != null)
        {
            targetCanvas.SetActive(true);
        }
    }
}