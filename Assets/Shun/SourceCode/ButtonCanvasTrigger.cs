
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ButtonCanvasTrigger : UdonSharpBehaviour
{

    [Header("このボタンを押した時に【表示】したいキャンバス（複数可）")]
    [SerializeField] private GameObject[] canvasesToActivate;

    [Header("このボタンを押した時に【非表示】にしたいキャンバス（あれば）")]
    [SerializeField] private GameObject[] canvasesToDeactivate;

    /// <summary>
    /// UIのボタンがクリックされた時に実行されるイベント
    /// </summary>
    public void OnButtonClick()
    {
        // 表示したいキャンバスをすべてアクティブにする
        if (canvasesToActivate != null)
        {
            for (int i = 0; i < canvasesToActivate.Length; i++)
            {
                if (canvasesToActivate[i] != null)
                {
                    canvasesToActivate[i].SetActive(true);
                }
            }
        }

        // 非表示にしたいキャンバスをすべて非アクティブにする
        if (canvasesToDeactivate != null)
        {
            for (int i = 0; i < canvasesToDeactivate.Length; i++)
            {
                if (canvasesToDeactivate[i] != null)
                {
                    canvasesToDeactivate[i].SetActive(false);
                }
            }
        }
    }
}